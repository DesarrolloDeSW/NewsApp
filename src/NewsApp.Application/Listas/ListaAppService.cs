using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace NewsApp.Listas
{
    public class ListaAppService : NewsAppAppService, IListaAppService
    {
        private readonly IListaRepository _listaRepository;
        private readonly ListaManager _listaManager;

        public ListaAppService(
            IListaRepository listaRepository,
            ListaManager listaManager)
        {
            _listaRepository = listaRepository;
            _listaManager = listaManager;
        }

        public async Task<ICollection<ListaDto>> GetListasAsync()
        {
            var listas = await _listaRepository.GetListAsync();

            return ObjectMapper.Map<ICollection<Lista>, ICollection<ListaDto>>(listas);
        }

        public async Task<ListaDto> PostListaAsync(string Nombre, string Descripcion, Guid idUsuario)
        {
            ICollection<string> Etiquetas = new List<string>();
            Lista ListaNueva= new Lista { Nombre = Nombre, Descripcion=Descripcion, UsuarioId=idUsuario, FechaCreacion=DateTime.Today,Alerta=false, Etiquetas = Etiquetas};
            var respuesta = await _listaRepository.InsertAsync(ListaNueva);
            return ObjectMapper.Map<Lista, ListaDto>(respuesta);
        }

        public async Task<ListaDto> UpdateListaAsync(int id, string? Nombre, string? Descripcion)
        {
            var lista = await _listaRepository.GetAsync(id);

            if (Nombre != null)
            {
                if (lista.Nombre!= Nombre)
                { await _listaManager.CambiarNombreAsync(lista, Nombre); }
            }

            if (Descripcion != null)
            {
                if (lista.Descripcion != Descripcion)
                { await _listaManager.CambiarDescripcionAsync(lista, Descripcion); }
            }

            var respuesta = await _listaRepository.UpdateAsync(lista);
            return ObjectMapper.Map<Lista, ListaDto>(respuesta);
        }

        public async Task<ListaDto> DeleteListaAsync(int id)
        {
            var respuesta = await _listaRepository.GetAsync(id);
            await _listaRepository.DeleteAsync(id);
            return ObjectMapper.Map<Lista, ListaDto>(respuesta);
        }
    }
}
