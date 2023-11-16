using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace NewsApp.Listas
{
    public interface IListaAppService : IApplicationService
    {
        Task<ICollection<ListaDto>> GetListasAsync();
        Task<ListaDto> PostListaAsync(string Nombre, string Descripcion, Guid idUsuario);
        Task<ListaDto> UpdateListaAsync(int id, string? Nombre, string? Descripcion);
        Task<ListaDto> DeleteListaAsync(int id);
    }
}
