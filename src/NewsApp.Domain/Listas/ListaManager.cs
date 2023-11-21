using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace NewsApp.Listas;

public class ListaManager : DomainService
{
    private readonly IListaRepository _listaRepository;

    public ListaManager(IListaRepository ListaRepository)
    {
        _listaRepository= ListaRepository;
    }

    public async Task<Lista> CreateAsync(string nombre, string? descripcion, int? parentId, IdentityUser usuario)
    {
        var listaExistente = await _listaRepository.FindByNameAsync(nombre);
        if (listaExistente != null && listaExistente.UsuarioId == usuario.Id)
        {
            throw new ListaYaExiste(nombre);
        }

        var lista = new Lista { Nombre = nombre, Descripcion = descripcion, UsuarioId = usuario.Id, FechaCreacion = DateTime.Today, Alerta = false};

        if (parentId is not null)
        {
            if (parentId!=0)
            { 
                var listaPadre = await _listaRepository.GetAsync(parentId.Value, includeDetails: true);
                listaPadre.Listas.Add(lista);
            }
        }

        return lista;
    }

    public async Task CambiarNombreAsync(
        [NotNull] Lista lista,
        [NotNull] string nombreNuevo)
    {
        Check.NotNull(lista, nameof(lista));
        Check.NotNullOrWhiteSpace(nombreNuevo, nameof(nombreNuevo));

        var listaExistente = await _listaRepository.FindByNameAsync(nombreNuevo);
        if (listaExistente != null && listaExistente.Id != lista.Id)
        {
            throw new ListaYaExiste(nombreNuevo);
        }

        lista.CambiarNombre(nombreNuevo);
    }

    public async Task CambiarDescripcionAsync(
        [NotNull] Lista lista,
        [NotNull] string descripcionNueva)
    {
        Check.NotNull(lista, nameof(lista));
        Check.NotNullOrWhiteSpace(descripcionNueva, nameof(descripcionNueva));

        var listaExistente = await _listaRepository.FindByNameAsync(descripcionNueva);
        if (listaExistente != null && listaExistente.Id != lista.Id)
        {
            throw new ListaYaExiste(descripcionNueva);
        }

        lista.CambiarDescripcion(descripcionNueva);
    }
}