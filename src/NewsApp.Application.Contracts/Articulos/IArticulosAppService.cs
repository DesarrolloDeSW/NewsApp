using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using NewsApp.Articulos;
using System.Net.NetworkInformation;
using NewsApp.Noticias;


namespace NewsApp.Articulos
{
    public interface IArticulosAppService : IApplicationService
    {
        Task<ICollection<NoticiaDto>> GetArticulosConVistoAsync(string cadena, CodigosIdiomas? idioma, OrdenBusqueda? ordenarPor, string? urls);
        Task<ICollection<NoticiaDto>> GetNoticiasApiNewsAsync(string cadena, CodigosIdiomas? idioma, OrdenBusqueda? ordenarPor);
    }
}
