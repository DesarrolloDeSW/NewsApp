using NewsApp.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsApp.Articulos;
using AutoMapper;
using System.Text.Json;
using System.Collections.ObjectModel;

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

        public ICollection<ArticuloDto> GetArticulosNuestros(string cadena, CodigosIdiomas? idioma, OrdenBusqueda? ordenarPor, string? url1, string? url2, string? url3)
        {
            // Llama a GetArticulos para obtener el JSON de artículos
            string jsonArticulos = GetArticulos(cadena, idioma, ordenarPor);

            // Deserializa el JSON en una lista de objetos ArticuloJson
            var articulosJson = JsonSerializer.Deserialize<List<Articulo>>(jsonArticulos);
            
            var conjuntoUrls = new HashSet<string> { url1, url2, url3 }; // Define el conjunto de URLs

            MarcarArticulosComoVistos(conjuntoUrls, articulosJson); // Marca los artículos como "Vistos"

            // Mapea los objetos ArticuloJson a ArticuloDto utilizando AutoMapper
            var articulosDto = ObjectMapper.Map<ICollection<Articulo>, ICollection<ArticuloDto>>(articulosJson);
            return articulosDto;

        }

        public void MarcarArticulosComoVistos(ICollection<string> urls, ICollection<Articulo> articulos)
        {
            foreach (var articulo in articulos)
            {
                if (urls.Contains(articulo.Url))
                {
                    articulo.Visto = true;
                }
            }
        }


    }
}
