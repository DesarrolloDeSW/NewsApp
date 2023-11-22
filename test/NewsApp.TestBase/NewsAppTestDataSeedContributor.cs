using NewsApp.Listas;
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
    public NewsAppTestDataSeedContributor(IListaRepository listaRepository, IdentityUserManager identityUserManager)
    {
        _listaRepository = listaRepository;
        _identityUserManager = identityUserManager;
    }
    public async Task SeedAsync(DataSeedContext context)
    {

        // Añadir usuarios
        IdentityUser identityUser1 = new IdentityUser(Guid.Parse("2e701e62-0953-4dd3-910b-dc6cc93ccb0d"), "admin", "admin@abp.io");
        await _identityUserManager.CreateAsync(identityUser1, "1q2w3E*");

        // Añadir 
        await _listaRepository.InsertAsync(new Lista {Nombre = "Primera Lista", Descripcion= "Descripción de la primera lista", UsuarioId = identityUser1.Id, Alerta=false, FechaCreacion=DateTime.Today});
        await _listaRepository.InsertAsync(new Lista { Nombre = "Segunda Lista", Descripcion = "Descripción de la segunda lista", UsuarioId = identityUser1.Id, Alerta = false, FechaCreacion = DateTime.Today});
        await _listaRepository.InsertAsync(new Lista { Nombre = "Tercera Lista", Descripcion = "Descripción de la tercera lista", UsuarioId = identityUser1.Id, Alerta = false, FechaCreacion = DateTime.Today});
        
    }
}
