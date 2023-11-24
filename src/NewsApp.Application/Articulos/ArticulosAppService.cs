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
using Volo.Abp.Application.Dtos;
using NewsApp.Noticias;

namespace NewsApp.Articulos
{
    public class ArticulosAppService : NewsAppAppService, IArticulosAppService
    {

        public async Task<ICollection<NoticiaDto>> GetNoticiasApiNewsAsync(string cadena, CodigosIdiomas? idioma, OrdenBusqueda? ordenarPor)

        {
            var _gestorNewsAPI = new GestorNewsAPI();
            var articulos = await _gestorNewsAPI.GetNoticiasAsync(cadena, idioma, ordenarPor);
            return ObjectMapper.Map<ICollection<ArticuloDto>, ICollection<NoticiaDto>>(articulos);
        }

        public async Task<ICollection<NoticiaDto>> GetArticulosConVistoAsync(string cadena, CodigosIdiomas? idioma, OrdenBusqueda? ordenarPor, string? urls)
        {
            var noticias= await GetNoticiasApiNewsAsync(cadena, idioma, ordenarPor);

            if (urls != null)
            {
                var conjuntoUrls = SepararYAgregarAHashSet(urls);
                
                MarcarNoticiasComoVistas(conjuntoUrls, noticias); // Marca las noticias como "Vistas"
            }

            return noticias;

        }

        private void MarcarNoticiasComoVistas(ICollection<string> urls, ICollection<NoticiaDto> noticias)
        {
            foreach (var noticia in noticias)
            {
                if (urls.Contains(noticia.Url))
                {
                    noticia.Visto = true;
                }
            }
        }


        public static HashSet<string> SepararYAgregarAHashSet(string input)
        {
            HashSet<string> conjunto = new HashSet<string>();

            // Dividir la cadena en elementos usando comas como delimitadores
            string[] elementos = input.Split(',');

            foreach (string elemento in elementos)
            {
                // Agregar cada elemento al conjunto
                conjunto.Add(elemento);
            }

            return conjunto;
        }

    }
}