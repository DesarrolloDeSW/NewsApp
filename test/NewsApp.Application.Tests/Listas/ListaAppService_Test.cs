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

        [Fact]
        public async Task Should_Update_A_Lista()
        {
            //Act
            var lista1 = await _listaAppService.UpdateListaAsync(1, null,"NuevaDesc");
            var lista2 = await _listaAppService.UpdateListaAsync(2, "Lista 2", null);

            //Assert
            lista1.Nombre.ShouldBe("Primera Lista");
            lista1.Descripcion.ShouldBe("NuevaDesc");
            lista2.Nombre.ShouldBe("Lista 2");
            lista2.Descripcion.ShouldBe("Descripción de la segunda lista");

        }

        [Fact]
        public async Task Should_Delete_A_Lista()
        {
            //Act
            var antes = await _listaAppService.GetListasAsync();
            await _listaAppService.DeleteListaAsync(3);
            var despues = await _listaAppService.GetListasAsync();

            //Assert
            antes.Count.ShouldBeGreaterThan(despues.Count);

        }
    }
}
