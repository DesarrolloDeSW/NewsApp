using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using NewsApp.Articulos;

namespace NewsApp.Articulos
{
    public interface IArticulosAppService : IApplicationService
    {
        string GetArticulos(string cadena, CodigosIdiomas? idioma, OrdenBusqueda? ordenarPor);
        public ICollection<ArticuloDto> GetArticulosNuestros(string cadena, CodigosIdiomas? idioma, OrdenBusqueda? ordenarPor);
    }
}
