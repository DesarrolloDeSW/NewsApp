﻿using NewsApp.Listas;
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
    public NewsAppTestDataSeedContributor(IListaRepository listaRepository, IdentityUserManager identityUserManager, IIdentityUserRepository identityUserRepository)
    {
        _listaRepository = listaRepository;
        _identityUserManager = identityUserManager;
        _identityUserRepository = identityUserRepository;
    }
    public async Task SeedAsync(DataSeedContext context)
    {

        // Añadir usuarios
        IdentityUser identityUser = new IdentityUser(Guid.Parse("2e701e62-0953-4dd3-910b-dc6cc93ccb0d"), "admin", "admin@abp.io");
        await _identityUserManager.CreateAsync(identityUser, "1q2w3E*");

        var user = await _identityUserRepository.InsertAsync(identityUser);

        // Añadir 
        await _listaRepository.InsertAsync(new Lista {Nombre = "Primera Lista", Descripcion= "Descripción de la primera lista", UsuarioId = identityUser.Id, Alerta=false, FechaCreacion=DateTime.Today});
        await _listaRepository.InsertAsync(new Lista { Nombre = "Segunda Lista", Descripcion = "Descripción de la segunda lista", UsuarioId = identityUser.Id, Alerta = false, FechaCreacion = DateTime.Today});
        await _listaRepository.InsertAsync(new Lista { Nombre = "Tercera Lista", Descripcion = "Descripción de la tercera lista", UsuarioId = identityUser.Id, Alerta = false, FechaCreacion = DateTime.Today});
        
    }
}
