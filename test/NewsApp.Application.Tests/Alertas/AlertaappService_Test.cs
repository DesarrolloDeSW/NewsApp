using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using NewsApp.Alertas;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Uow;
using NewsApp.EntityFrameworkCore;
using System.Collections;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.Users;

namespace NewsApp.Alertas
{
    public class AlertaAppService_Test : NewsAppApplicationTestBase
    {
        private readonly IAlertaAppService _alertaAppService;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IDbContextProvider<NewsAppDbContext> _dbContextProvider;


        public AlertaAppService_Test()
        {
            _alertaAppService = GetRequiredService<IAlertaAppService>();
            _dbContextProvider = GetRequiredService<IDbContextProvider<NewsAppDbContext>>();
            _unitOfWorkManager = GetRequiredService<IUnitOfWorkManager>();
        }


        [Fact]
        public async Task Should_Create_A_Valid_Alerta()
        {
            //Arrange
            var cadena = "Cadena de Prueba";

            //Act
            var result = await _alertaAppService.PostAlertaAsync(cadena);

            //Assert
            // Se verifican los datos devueltos por el servicio
            result.ShouldNotBeNull();
            result.Id.ShouldBePositive();
            // se verifican los datos persistidos por el servicio

            using (var uow = _unitOfWorkManager.Begin())
            {
                var dbContext = await _dbContextProvider.GetDbContextAsync();
                dbContext.Alertas.FirstOrDefault(t => t.Id == result.Id).ShouldNotBeNull();
                dbContext.Alertas.FirstOrDefault(t => t.Id == result.Id).CadenaBusqueda.ShouldBe(cadena);
            }

        }

        [Fact]
        public async Task Should_Create_A_Valid_Notificacion()
        {
            //Arrange
            var cadena = "Busqueda de Prueba";

            //Act
            var result = await _alertaAppService.PostNotificacionAsync(1);

            //Assert
            // Se verifican los datos devueltos por el servicio
            result.ShouldNotBeNull();
            result.Id.ShouldBePositive();
            // se verifican los datos persistidos por el servicio

            using (var uow = _unitOfWorkManager.Begin())
            {
                var dbContext = await _dbContextProvider.GetDbContextAsync();
                dbContext.Notificaciones.FirstOrDefault(t => t.Id == result.Id).ShouldNotBeNull();
                dbContext.Notificaciones.FirstOrDefault(t => t.Id == result.Id).CadenaBusqueda.ShouldBe(cadena);
            }

        }

        [Fact]
        public async Task Should_Get_All_Notificaciones()
        {
            //Act
            var notificaciones = await _alertaAppService.GetNotificacionesAsync();

            //Assert
            notificaciones.ShouldNotBeNull();
            notificaciones.Count.ShouldBeGreaterThan(2);
        }

        [Fact]
        public async Task Should_MarcarComoLeidas()
        {
            //Act
            await _alertaAppService.MarcarNotificacionesComoLeidas();
            var notificaciones = await _alertaAppService.GetNotificacionesAsync();

            //Assert
            foreach (var notificacion in notificaciones)
            {
                notificacion.Leida.ShouldBeEquivalentTo(true);
            }
        }
    }
}