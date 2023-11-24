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

namespace NewsApp.Listas
{
    public class ListaManager_Integration_Tests : NewsAppDomainTestBase
    {
        private readonly ListaManager _listaManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ICurrentUser _currentUser;
        private readonly ICurrentPrincipalAccessor _currentPrincipalAccessor;
        private readonly IRepository<IdentityUser, Guid> _identityRepository;

        public ListaManager_Integration_Tests()
        {
            _listaManager = GetRequiredService<ListaManager>();
            _userManager = GetRequiredService<UserManager<IdentityUser>>();
            _currentUser = GetRequiredService<ICurrentUser>();
            _currentPrincipalAccessor = GetRequiredService<ICurrentPrincipalAccessor>();
            _identityRepository = GetRequiredService<IRepository<IdentityUser, Guid>>();
        }

        [Fact]
        public async Task Should_Create_A_Lista()
        {
            // Arrange
            var nombre = "Lista agregada";
            var userId = _currentUser.Id.GetValueOrDefault();
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var user2 = await _identityRepository.GetAsync(_currentUser.Id.GetValueOrDefault());

            // Act
            var lista = await _listaManager.CreateAsync(nombre, null, null, user2);

            //Assert
            lista.ShouldNotBeNull();
        }
    }
}
