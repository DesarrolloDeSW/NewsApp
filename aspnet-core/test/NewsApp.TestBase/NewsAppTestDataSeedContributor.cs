using NewsApp.Alertas;
using NewsApp.API;
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
    private readonly IAlertaRepository _alertaRepository;
    private readonly IRepository<Notificacion, int> _notificacionRepository;
    private readonly IRepository<AccesoAPI, int> _monitoreoRepository;

    public NewsAppTestDataSeedContributor(IListaRepository listaRepository, IdentityUserManager identityUserManager, 
        IIdentityUserRepository identityUserRepository, IRepository<Noticia,int> noticiaRepository,
        IAlertaRepository alertaRepository, IRepository<Notificacion,int> notificacionRepository, IRepository<AccesoAPI,int> monitoreoRepository)
    {
        _listaRepository = listaRepository;
        _identityUserManager = identityUserManager;
        _identityUserRepository = identityUserRepository;
        _noticiaRepository = noticiaRepository;
        _alertaRepository = alertaRepository;
        _notificacionRepository = notificacionRepository;
        _monitoreoRepository = monitoreoRepository;
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

        // Añadir alertas
        await _alertaRepository.InsertAsync(new Alerta { Activa = true, CadenaBusqueda = "Busqueda de Prueba", FechaCreacion = DateTime.Today, UsuarioId = identityUser.Id });
        await _alertaRepository.InsertAsync(new Alerta { Activa = true, CadenaBusqueda = "Messi", FechaCreacion = DateTime.Today, UsuarioId = identityUser.Id });

        // Añadir notificaciones
        await _notificacionRepository.InsertAsync(new Notificacion { UsuarioId = identityUser.Id, FechaEnvio = DateTime.Today, CadenaBusqueda = "Busqueda de Prueba 1", Leida = false });
        await _notificacionRepository.InsertAsync(new Notificacion { UsuarioId = identityUser.Id, FechaEnvio = DateTime.Today, CadenaBusqueda = "Busqueda de Prueba 2", Leida = false });
        await _notificacionRepository.InsertAsync(new Notificacion { UsuarioId = identityUser.Id, FechaEnvio = DateTime.Today, CadenaBusqueda = "Busqueda de Prueba 3", Leida = false });

        //Añadir accesos
        DateTime tiempoInicio = new DateTime(2023, 12, 3, 10, 30, 0);
        DateTime tiempoFin1 = new DateTime(2023, 12, 3, 10, 30, 1);
        DateTime tiempoFin2 = new DateTime(2023, 12, 3, 10, 30, 2);
        DateTime tiempoFin3 = new DateTime(2023, 12, 3, 10, 30, 3);
        DateTime tiempoFin4 = new DateTime(2023, 12, 3, 10, 30, 2);

        await _monitoreoRepository.InsertAsync(new AccesoAPI
        {
            UsuarioId = identityUser.Id,
            TiempoInicio = tiempoInicio,
            TiempoFin = tiempoFin1,
            TiempoTotal = tiempoFin1 - tiempoInicio,
            ErrorCode = Articulos.ErrorCodes.TodoBien,
            ErrorMessage = null
        });

        await _monitoreoRepository.InsertAsync(new AccesoAPI
        {
            UsuarioId = identityUser.Id,
            TiempoInicio = tiempoInicio,
            TiempoFin = tiempoFin2,
            TiempoTotal = tiempoFin2 - tiempoInicio,
            ErrorCode = Articulos.ErrorCodes.TodoBien,
            ErrorMessage = null
        });

        await _monitoreoRepository.InsertAsync(new AccesoAPI
        {
            UsuarioId = identityUser.Id,
            TiempoInicio = tiempoInicio,
            TiempoFin = tiempoFin3,
            TiempoTotal = tiempoFin3 - tiempoInicio,
            ErrorCode = Articulos.ErrorCodes.TodoBien,
            ErrorMessage = null
        });

        await _monitoreoRepository.InsertAsync(new AccesoAPI
        {
            UsuarioId = identityUser.Id,
            TiempoInicio = tiempoInicio,
            TiempoFin = tiempoFin4,
            TiempoTotal = tiempoFin4 - tiempoInicio,
            ErrorCode = Articulos.ErrorCodes.ApiKeyInvalid,
            ErrorMessage = "La API Key es Inválida"
        }) ;

    }
}
