using NewsApp.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Articulos
{
    public class ArticulosAppService : NewsAppAppService, IArticulosAppService
    {
        public string GetArticulos(string cadena)
        {
            var _gestorNewsAPI = new GestorNewsAPI();
            string articulos = _gestorNewsAPI.GetNoticias(cadena);
            return articulos;
        }
    }
}
