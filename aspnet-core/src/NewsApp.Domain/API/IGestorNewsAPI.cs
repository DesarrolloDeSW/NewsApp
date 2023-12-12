using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewsApp.Articulos;
using System.Threading.Tasks;
using NewsAPI.Models;

namespace NewsApp.API
{
    public interface IGestorNewsAPI
    {
        Task<(ICollection<ArticuloDto> articulos, Error error)> GetNoticiasAsync(string cadena, CodigosIdiomas? idioma, OrdenBusqueda? ordenarPor);
    }
}
