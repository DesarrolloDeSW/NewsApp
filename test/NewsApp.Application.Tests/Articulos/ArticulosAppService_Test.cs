using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace NewsApp.Articulos
{
    public class ArticulosAppService_Test : NewsAppApplicationTestBase
    {
        private readonly IArticulosAppService _articulosAppService;

        public ArticulosAppService_Test()
        {
            _articulosAppService = GetRequiredService<IArticulosAppService>();
        }

        [Fact]
        public async Task Should_Buscar_Articulos()
        {
            //Arrange
            var cadena = "Apple";
            CodigosIdiomas idioma = CodigosIdiomas.ES;
            OrdenBusqueda orden = OrdenBusqueda.relevancia;

            //Act
            var articulos = await _articulosAppService.GetArticulosConVistoAsync(cadena, idioma, orden, "");

            //Assert
            articulos.ShouldNotBeNull();
            articulos.Count.ShouldBeGreaterThan(1);
        }
    }
}
