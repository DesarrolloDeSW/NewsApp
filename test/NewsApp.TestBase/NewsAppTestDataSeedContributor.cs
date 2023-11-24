using NewsApp.Listas;
using NewsApp.Noticias;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace NewsApp;

public class NewsAppTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IListaRepository _listaRepository;
    private readonly IdentityUserManager _identityUserManager;
    private readonly IIdentityUserRepository _identityUserRepository;
    private readonly IRepository<Noticia, int> _noticiaRepository;
    public NewsAppTestDataSeedContributor(IListaRepository listaRepository, IdentityUserManager identityUserManager, 
        IIdentityUserRepository identityUserRepository, IRepository<Noticia,int> noticiaRepository)
    {
        _listaRepository = listaRepository;
        _identityUserManager = identityUserManager;
        _identityUserRepository = identityUserRepository;
        _noticiaRepository = noticiaRepository;
    }
    public async Task SeedAsync(DataSeedContext context)
    {

        // Añadir usuarios
        IdentityUser identityUser = new IdentityUser(Guid.Parse("2e701e62-0953-4dd3-910b-dc6cc93ccb0d"), "admin", "admin@abp.io");
        await _identityUserManager.CreateAsync(identityUser, "1q2w3E*");

        var user = await _identityUserRepository.InsertAsync(identityUser);

        // Añadir listas
        await _listaRepository.InsertAsync(new Lista {Nombre = "Primera Lista", Descripcion= "Descripción de la primera lista", UsuarioId = identityUser.Id, Alerta=false, FechaCreacion=DateTime.Today});
        await _listaRepository.InsertAsync(new Lista { Nombre = "Segunda Lista", Descripcion = "Descripción de la segunda lista", UsuarioId = identityUser.Id, Alerta = false, FechaCreacion = DateTime.Today});
        await _listaRepository.InsertAsync(new Lista { Nombre = "Tercera Lista", Descripcion = "Descripción de la tercera lista", UsuarioId = identityUser.Id, Alerta = false, FechaCreacion = DateTime.Today});

        // Añadir noticias
        await _noticiaRepository.InsertAsync(new Noticia { 
            Titulo = "\"Te clavo el visto la próxima\": el enfado de Messi con Ibai en directo y tras su octavo Balón de Oro no tiene desperdicio",
            Autor = "Antonio Vallejo",
            Descripcion = "Ayer tuvo lugar la celebración de la gala del Balón de Oro, un evento que ha podido significar un déjà vu para muchos al ver como Lionel Messi se llevaba su octavo Balón de Oro. Para los españoles también ha sido todo un orgullo el hecho de que Aitana Bonmatí…",
            Url = "https://www.genbeta.com/actualidad/te-clavo-visto-proxima-enfado-messi-ibai-directo-su-octavo-balon-oro-no-tiene-desperdicio",
            Contenido = "Ayer tuvo lugar la celebración de la gala del Balón de Oro, un evento que ha podido significar un déjà vu para muchos al ver como Lionel Messi se llevaba su octavo Balón de Oro. Para los españoles ta… [+2504 chars]",
            FechaPublicacion = DateTime.Today,
            Fuente = "Genbeta.com"});
    }
}
