using NewsApp.Listas;
using Volo.Abp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.Identity;
using Shouldly;
using Volo.Abp.Users;
using Volo.Abp.Security.Claims;
using Volo.Abp.Domain.Repositories;

namespace NewsApp.Alertas
{
    public class AlertaManager_Integration_Tests : NewsAppDomainTestBase
    {
        private readonly AlertaManager _alertaManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ICurrentUser _currentUser;
        private readonly ICurrentPrincipalAccessor _currentPrincipalAccessor;
        private readonly IRepository<IdentityUser, Guid> _identityRepository;
        private readonly IAlertaRepository _alertaRepository;
        private readonly IRepository<Notificacion, int> _notificacionRepository;

        public AlertaManager_Integration_Tests()
        {
            _alertaManager = GetRequiredService<AlertaManager>();
            _userManager = GetRequiredService<UserManager<IdentityUser>>();
            _currentUser = GetRequiredService<ICurrentUser>();
            _currentPrincipalAccessor = GetRequiredService<ICurrentPrincipalAccessor>();
            _identityRepository = GetRequiredService<IRepository<IdentityUser, Guid>>();
            _alertaRepository = GetRequiredService<IAlertaRepository>();
            _notificacionRepository = GetRequiredService<IRepository<Notificacion,int>>();
        }

        [Fact]
        public async Task Should_Create_An_Alerta()
        {
            // Arrange
            var cadena = "Cadena de Prueba";
            var userId = _currentUser.Id.GetValueOrDefault();
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var user2 = await _identityRepository.GetAsync(_currentUser.Id.GetValueOrDefault());

            // Act
            var alerta = await _alertaManager.CreateAsync(cadena, user2);

            //Assert
            alerta.ShouldNotBeNull();
            alerta.CadenaBusqueda.ShouldBeEquivalentTo(cadena);
        }

        [Fact]
        public async Task Should_Create_A_Notificacion()
        {
            // Arrange
            var alerta = await _alertaRepository.FindAsync(1);

            // Act
            var notif = await _alertaManager.CreateNotificacionAsync(alerta);

            //Assert
            notif.ShouldNotBeNull();
            notif.CadenaBusqueda.ShouldBeEquivalentTo(alerta.CadenaBusqueda);
        }

        [Fact]
        public async Task Should_MarcarComoLeidas()
        {
            // Arrange
            var notificaciones = await _notificacionRepository.GetListAsync();

            // Act
            await _alertaManager.MarcarNotificacionesComoLeidas(notificaciones);

            // Assert
            foreach (var notificacion in notificaciones)
            {
                notificacion.Leida.ShouldBeEquivalentTo(true);
            }
        }
    }
}