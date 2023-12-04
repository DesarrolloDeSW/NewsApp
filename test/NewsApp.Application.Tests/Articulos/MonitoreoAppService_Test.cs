using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewsApp.Articulos
{
    public class MonitoreoAppService_Test : NewsAppApplicationTestBase
    {
        private readonly IMonitoreoAPIAppService _monitoreoAPIAppService;

        public MonitoreoAppService_Test()
        {
            _monitoreoAPIAppService = GetRequiredService<IMonitoreoAPIAppService>();
        }

        [Fact]
        public async Task Should_Get_TiempoPromedio()
        {
            //Arrange
            TimeSpan tiempoCorrecto = TimeSpan.FromSeconds(2);

            //Act
            var tiempoPromedio = await _monitoreoAPIAppService.GetTiempoPromedioAsync();

            //Assert
            tiempoPromedio.ShouldBeEquivalentTo(tiempoCorrecto);
        }

        [Fact]
        public async Task Should_Get_CantidadTotalAccesos()
        {
            //Arrange
            long cantidadCorrecta = 4;

            //Act
            var cantidad = await _monitoreoAPIAppService.GetCantidadTotalAccesosAsync();

            //Assert
            cantidad.ShouldBeEquivalentTo(cantidadCorrecta);
        }

        [Fact]
        public async Task Should_Get_PorcentajeExito()
        {
            //Arrange
            float porcentajeCorrecto = 75;
            //Act
            var porcentaje = await _monitoreoAPIAppService.GetPorcentajeExitoAsync();

            //Assert
            porcentaje.ShouldBeEquivalentTo(porcentajeCorrecto);
        }

        [Fact]
        public async Task Should_Get_CantidadAccesosUsuario()
        {
            //Arrange
            long cantidadCorrecta = 4;
            var idUsuario = Guid.Parse("2e701e62-0953-4dd3-910b-dc6cc93ccb0d");

            //Act
            var cantidad = await _monitoreoAPIAppService.GetCantidadAccesosUsuarioAsync(idUsuario);

            //Assert
            cantidad.ShouldBeEquivalentTo(cantidadCorrecta);
        }
    }
}
