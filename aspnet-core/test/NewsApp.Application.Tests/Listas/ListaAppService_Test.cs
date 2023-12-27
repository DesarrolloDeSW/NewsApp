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
using NewsApp.Noticias;
using System.Collections;
using Microsoft.AspNetCore.Identity;

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

        [Fact]
        public async Task Should_Agregar_Noticia_A_Lista()
        {
            // Arrange 
            var noticia = new NoticiaDto
            {
                Titulo = "\"Te clavo el visto la próxima\": el enfado de Messi con Ibai en directo y tras su octavo Balón de Oro no tiene desperdicio",
                Autor = "Autor de Pruebas",
                Descripcion = "Ayer tuvo lugar la celebración de la gala del Balón de Oro, un evento que ha podido significar un déjà vu para muchos al ver como Lionel Messi se llevaba su octavo Balón de Oro. Para los españoles también ha sido todo un orgullo el hecho de que Aitana Bonmatí…",
                Url = "https://www.genbeta.com/actualidad/te-clavo-visto-proxima-enfado-messi-ibai-directo-su-octavo-balon-oro-no-tiene-desperdicio",
                Contenido = "Ayer tuvo lugar la celebración de la gala del Balón de Oro, un evento que ha podido significar un déjà vu para muchos al ver como Lionel Messi se llevaba su octavo Balón de Oro. Para los españoles ta… [+2504 chars]",
                FechaPublicacion = DateTime.Today,
                Fuente = "Genbeta.com"
            };

            var lista = await _listaAppService.GetListaAsync(1);
            var antes = lista.Noticias.Count;
            var input = new AgregarNoticiaDto { IdLista = 1, Noticia = noticia};

            //Act
            await _listaAppService.AgregarNoticiaAsync(input);
            var listaActualizada = await _listaAppService.GetListaAsync(1);
            var noticias = listaActualizada.Noticias;

            // Assert
            noticias.Count.ShouldBeGreaterThan(antes);
            noticias.ShouldContain(n => n.Autor == "Autor de Pruebas");
        }

        [Fact]
        public async Task Should_Get_All_SublistasLista()
        {
            //Arrange
            var input = new CreateListaDto { Nombre = "Sublista", ParentId = 1 };
            await _listaAppService.PostListaAsync(input);

            //Act
            var sublistas = await _listaAppService.GetSubListasListaAsync(1);

            //Assert
            sublistas.ShouldNotBeNull();
            sublistas.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Should_Get_All_NoticiasLista()
        {
            // Arrange 
            var noticia = new NoticiaDto
            {
                Titulo = "\"Te clavo el visto la próxima\": el enfado de Messi con Ibai en directo y tras su octavo Balón de Oro no tiene desperdicio",
                Autor = "Autor de Pruebas",
                Descripcion = "Ayer tuvo lugar la celebración de la gala del Balón de Oro, un evento que ha podido significar un déjà vu para muchos al ver como Lionel Messi se llevaba su octavo Balón de Oro. Para los españoles también ha sido todo un orgullo el hecho de que Aitana Bonmatí…",
                Url = "https://www.genbeta.com/actualidad/te-clavo-visto-proxima-enfado-messi-ibai-directo-su-octavo-balon-oro-no-tiene-desperdicio",
                Contenido = "Ayer tuvo lugar la celebración de la gala del Balón de Oro, un evento que ha podido significar un déjà vu para muchos al ver como Lionel Messi se llevaba su octavo Balón de Oro. Para los españoles ta… [+2504 chars]",
                FechaPublicacion = DateTime.Today,
                Fuente = "Genbeta.com"
            };
            var input = new AgregarNoticiaDto { IdLista = 1, Noticia = noticia };
            await _listaAppService.AgregarNoticiaAsync(input);

            //Act
            var noticias = await _listaAppService.GetNoticiasListaAsync(1);

            //Assert
            noticias.ShouldNotBeNull();
            noticias.Count.ShouldBeGreaterThan(0);
        }

        /*
        public async Task<ICollection<ListaDto>> GetListasUsuarioAsync()
        {
            var userGuid = CurrentUser.Id.GetValueOrDefault();
            var listas = await _listaRepository.GetListAsync(l => l.UsuarioId == userGuid, includeDetails: true);

            return ObjectMapper.Map<ICollection<Lista>, ICollection<ListaDto>>(listas);
        }
        */

        [Fact]
        public async Task Should_Get_All_ListasUsuario()
        {
            //Act
            var listas = await _listaAppService.GetListasUsuarioAsync();

            //Assert
            listas.ShouldNotBeNull();
            listas.Count.ShouldBeGreaterThan(0);
        }

    }
}
