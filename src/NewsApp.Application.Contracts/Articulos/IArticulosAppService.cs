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
        public string GetArticulosApiNews(string cadena, CodigosIdiomas? idioma, OrdenBusqueda? ordenarPor);
    }
}
