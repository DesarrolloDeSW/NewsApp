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
        Task<ListaDto> GetListaAsync(int id);
        Task<ListaDto> PostListaAsync(CreateListaDto input);
        Task<ListaDto> UpdateListaAsync(UpdateListaDto input);
        Task<ListaDto> DeleteListaAsync(int id);
        Task<ListaDto> AgregarNoticiaAsync(AgregarNoticiaDto input);
    }
}
