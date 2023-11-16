using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace NewsApp.Listas;

public class ListaManager : DomainService
{
    private readonly IListaRepository _listaRepository;

    public ListaManager(IListaRepository ListaRepository)
    {
        _listaRepository= ListaRepository;
    }

    /*public async Task<Lista> CreateAsync(
        [NotNull] string Nombre,
        DateTime birthDate,
        [CanBeNull] string shortBio = null)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));

        var existingAuthor = await _authorRepository.FindByNameAsync(name);
        if (existingAuthor != null)
        {
            throw new AuthorAlreadyExistsException(name);
        }

        return new Author(
            GuidGenerator.Create(),
            name,
            birthDate,
            shortBio
        );
    }
    */

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