using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using NewsApp.Listas;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Uow;
using NewsApp.EntityFrameworkCore;

namespace NewsApp.Listas
{
    public class ListaAppService_Test:NewsAppApplicationTestBase
    {
        private readonly IListaAppService _listaAppService;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IDbContextProvider<NewsAppDbContext> _dbContextProvider;


        public ListaAppService_Test()
        {
            _listaAppService = GetRequiredService<IListaAppService>();
            _dbContextProvider = GetRequiredService<IDbContextProvider<NewsAppDbContext>>();
            _unitOfWorkManager = GetRequiredService<IUnitOfWorkManager>();
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
            //Arrange
            CreateListaDto input = new CreateListaDto { Nombre = "Lista creada" };

            //Act
            var result = await _listaAppService.PostListaAsync(input);

            //Assert
                // Se verifican los datos devueltos por el servicio
            result.ShouldNotBeNull();
            result.Id.ShouldBePositive();
                // se verifican los datos persistidos por el servicio
           
            using (var uow = _unitOfWorkManager.Begin())
            {
                var dbContext = await _dbContextProvider.GetDbContextAsync();
                dbContext.Listas.FirstOrDefault(t => t.Id == result.Id).ShouldNotBeNull();
                dbContext.Listas.FirstOrDefault(t => t.Id == result.Id).Nombre.ShouldBe(input.Nombre);
            }
           
        }
        
        [Fact]
        public async Task Should_Create_A_Valid_Sublista()
        {
            //Arrange
            var input = new CreateListaDto { Nombre = "Sublista", ParentId = 1};
            
            // Act
            var result = await _listaAppService.PostListaAsync(input);

            //Assert
                // Se verifican los datos devueltos por el servicio
            result.ShouldNotBeNull();
            result.Id.ShouldBePositive();
            // se verifican los datos persistidos por el servicio
            using (var uow = _unitOfWorkManager.Begin())
            {
                var dbContext = await _dbContextProvider.GetDbContextAsync();
                dbContext.Listas.FirstOrDefault(t => t.Id == result.Id).ShouldNotBeNull();
                dbContext.Listas.FirstOrDefault(t => t.Id == result.Id).Nombre.ShouldBe(input.Nombre);
            }
        }

        [Fact]
        public async Task Should_Update_A_Lista()
        {
            //Act
            var inputU1 = new UpdateListaDto { Id = 1, Nombre=null, Descripcion="NuevaDesc"};
            var lista1 = await _listaAppService.UpdateListaAsync(inputU1);

            var inputU2 = new UpdateListaDto { Id = 2, Nombre = "Lista 2", Descripcion = null };
            var lista2 = await _listaAppService.UpdateListaAsync(inputU2);

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
