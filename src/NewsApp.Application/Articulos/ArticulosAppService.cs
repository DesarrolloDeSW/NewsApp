using NewsApp.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsApp.Articulos;

namespace NewsApp.Articulos
{
    public class ArticulosAppService : NewsAppAppService, IArticulosAppService
    {
        public string GetArticulos(string cadena, CodigosIdiomas? idioma, OrdenBusqueda? ordenarPor)
        {
            var _gestorNewsAPI = new GestorNewsAPI();
            string articulos = _gestorNewsAPI.GetNoticias(cadena, idioma, ordenarPor);
            return articulos;
        }
    }
}
