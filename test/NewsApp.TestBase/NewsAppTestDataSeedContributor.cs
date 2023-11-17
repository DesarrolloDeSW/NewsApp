using NewsApp.Listas;
using System;
using System.Collections.Generic;
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
        IdentityUser identityUser1 = new IdentityUser(Guid.NewGuid(), "usuario1", "usuario1@email.com");
        await _identityUserManager.CreateAsync(identityUser1, "1q2w3E*");
        IdentityUser identityUser2 = new IdentityUser(Guid.NewGuid(), "usuario2", "usuario2@email.com");
        await _identityUserManager.CreateAsync(identityUser1, "1q2w3E*");
        IdentityUser identityUser3 = new IdentityUser(Guid.NewGuid(), "usuario3", "usuario3@email.com");
        await _identityUserManager.CreateAsync(identityUser1, "1q2w3E*");

        // Añadir listas

            // Lista vacía para etiquetas
        ICollection<string> ListaEtiquetas = new List<string>();

            // Listas
        await _listaRepository.InsertAsync(new Lista { Nombre = "Primera Lista", Descripcion= "Descripción de la primera lista", UsuarioId = identityUser3.Id, Alerta=false, FechaCreacion=DateTime.Today, Etiquetas= ListaEtiquetas});
        await _listaRepository.InsertAsync(new Lista { Nombre = "Segunda Lista", UsuarioId = identityUser2.Id, Alerta = false, FechaCreacion = DateTime.Today, Etiquetas = ListaEtiquetas });
        await _listaRepository.InsertAsync(new Lista { Nombre = "Tercera Lista", UsuarioId = identityUser1.Id, Alerta = false, FechaCreacion = DateTime.Today, Etiquetas = ListaEtiquetas });

    }
}
