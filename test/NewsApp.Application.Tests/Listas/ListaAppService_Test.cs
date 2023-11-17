using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Xunit;
using NewsApp.Listas;

namespace NewsApp.Listas
{
    public class ListaAppService_Test:NewsAppApplicationTestBase
    {
        private readonly IdentityUserManager _identityUserManager;
        private readonly IListaAppService _listaAppService;

        public ListaAppService_Test()
        {
            _listaAppService = GetRequiredService<IListaAppService>();
            _identityUserManager = GetRequiredService<IdentityUserManager>();
        }

        [Fact]
        public async Task Should_Get_All_Listas()
        {
            //Act
            var listas = await _listaAppService.GetListasAsync();

            //Assert
            listas.ShouldNotBeNull();
            listas.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Should_Create_A_Valid_Lista()
        {
            //Act
            var usuario = await _identityUserManager.FindByNameAsync("usuario1");
            var result = await _listaAppService.PostListaAsync("Lista creada", "Descripcion", usuario.Id);

            //Assert
            result.Nombre.ShouldBe("Lista creada");
            result.Descripcion.ShouldBe("Descripcion");
            result.Alerta.ShouldBe(false);
            result.Etiquetas.Count.ShouldBe(0);
            result.UsuarioId.ShouldBeEquivalentTo(usuario.Id);
        }
    }
}
