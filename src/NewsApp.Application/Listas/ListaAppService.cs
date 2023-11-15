using System;
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
        private readonly IRepository<Lista, int> _repository;

        public ListaAppService(IRepository<Lista, int> repository)
        {
            _repository = repository;
        }

        // hay que editar para que devuelva la lista de lectura de un usuario específico.

        public async Task<ICollection<ListaDto>> GetListasAsync()
        {
            var listas = await _repository.GetListAsync();

            return ObjectMapper.Map<ICollection<Lista>, ICollection<ListaDto>>(listas);
        }

        public async Task<ListaDto> PostListaAsync(string Nombre, string Descripcion, Guid idUsuario)
        {
            ICollection<string> Etiquetas = new List<string>();
            Lista ListaNueva= new Lista { Nombre = Nombre, Descripcion=Descripcion, UsuarioId=idUsuario, FechaCreacion=DateTime.Today,Alerta=false, Etiquetas = Etiquetas};
            var respuesta = await _repository.InsertAsync(ListaNueva);
            return ObjectMapper.Map<Lista, ListaDto>(respuesta);
        }
    }
}
