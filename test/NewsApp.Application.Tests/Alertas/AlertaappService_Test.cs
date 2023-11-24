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
            var cadena = "cadena de prueba";

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
    }
}