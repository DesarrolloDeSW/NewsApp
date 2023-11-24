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
using NewsApp.Noticias;

namespace NewsApp.Listas
{
    public class ListaManager_Integration_Tests : NewsAppDomainTestBase
    {
        private readonly ListaManager _listaManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ICurrentUser _currentUser;
        private readonly ICurrentPrincipalAccessor _currentPrincipalAccessor;
        private readonly IRepository<IdentityUser, Guid> _identityRepository;
        private readonly IRepository<Noticia, int> _noticiaRepository;

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

        [Fact]
        public async Task Should_Agregar_Noticia_A_Lista()
        {
            // Arrange
            var nombreLista = "Lista de prueba";

            var userId = _currentUser.Id.GetValueOrDefault();
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var user2 = await _identityRepository.GetAsync(_currentUser.Id.GetValueOrDefault());

            var lista = await _listaManager.CreateAsync(nombreLista, null, null, user);

            var antes = lista.Noticias.Count;


            // Act

            var noticia = new Noticia
            {
                Titulo = "\"Te clavo el visto la próxima\": el enfado de Messi con Ibai en directo y tras su octavo Balón de Oro no tiene desperdicio",
                Autor = "Autor de Prueba",
                Descripcion = "Ayer tuvo lugar la celebración de la gala del Balón de Oro, un evento que ha podido significar un déjà vu para muchos al ver como Lionel Messi se llevaba su octavo Balón de Oro. Para los españoles también ha sido todo un orgullo el hecho de que Aitana Bonmatí…",
                Url = "https://www.genbeta.com/actualidad/te-clavo-visto-proxima-enfado-messi-ibai-directo-su-octavo-balon-oro-no-tiene-desperdicio",
                Contenido = "Ayer tuvo lugar la celebración de la gala del Balón de Oro, un evento que ha podido significar un déjà vu para muchos al ver como Lionel Messi se llevaba su octavo Balón de Oro. Para los españoles ta… [+2504 chars]",
                FechaPublicacion = DateTime.Today,
                Fuente = "Genbeta.com"
            };

            await _listaManager.AgregarNoticia(noticia, lista);
            var noticias = lista.Noticias;

            // Assert
            noticias.Count.ShouldBeGreaterThan(antes);
            noticias.ShouldContain(n => n.Autor == "Autor de Prueba");
        }

    }
}
