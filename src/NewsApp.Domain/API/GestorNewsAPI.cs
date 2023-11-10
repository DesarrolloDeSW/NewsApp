using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System.Text.Json;
using NewsApp.Articulos;

namespace NewsApp.API
{
    public class GestorNewsAPI
    {
        public async Task<ICollection<ArticuloDto>> GetNoticiasAsync(string cadena, CodigosIdiomas? idioma, OrdenBusqueda? ordenarPor)
        {
            ICollection<ArticuloDto> responseList = new List<ArticuloDto>();

            // init with your API key
            var newsApiClient = new NewsApiClient("8dbe7bd0639844c5b12f46cdcfad503f");
            var articlesResponse = await newsApiClient.GetEverythingAsync(new EverythingRequest
            {
                Q = cadena,
                SortBy = GetOrden(ordenarPor),
                Language = GetIdioma(idioma),
                From = GetHaceUnMes()
            });

            if (articlesResponse.Status == Statuses.Ok)
            {
                articlesResponse.Articles.ForEach(t => responseList.Add(new ArticuloDto
                {
                    Author = t.Author,
                    Title = t.Title,
                    Description = t.Description,
                    Url = t.Url,
                    PublishedAt = t.PublishedAt,
                    UrlToImage = t.UrlToImage,
                    Content=t.Content,
                    Source=t.Source.Name

                })) ;
            }
            else throw new Exception("Error: " + articlesResponse.Status);

            //TODO: falta registrar los tiempos de acceso de la API
            return responseList;
        }


        // Método que da fecha de hace un mes
        private DateTime GetHaceUnMes()
        {
            return DateTime.Now.AddMonths(-1);
        }

        // Método que da idioma
        private NewsAPI.Constants.Languages GetIdioma(CodigosIdiomas? Codigo)
        {
            switch (Codigo)
            {
                case CodigosIdiomas.AR:
                    return NewsAPI.Constants.Languages.AR;
                case CodigosIdiomas.DE:
                    return NewsAPI.Constants.Languages.DE;
                case CodigosIdiomas.EN:
                    return NewsAPI.Constants.Languages.EN;
                case CodigosIdiomas.FR:
                    return NewsAPI.Constants.Languages.FR;
                case CodigosIdiomas.HE:
                    return NewsAPI.Constants.Languages.HE;
                case CodigosIdiomas.IT:
                    return NewsAPI.Constants.Languages.IT;
                case CodigosIdiomas.NL:
                    return NewsAPI.Constants.Languages.NL;
                case CodigosIdiomas.NO:
                    return NewsAPI.Constants.Languages.NO;
                case CodigosIdiomas.PT:
                    return NewsAPI.Constants.Languages.PT;
                case CodigosIdiomas.RU:
                    return NewsAPI.Constants.Languages.RU;
                case CodigosIdiomas.SV:
                    return NewsAPI.Constants.Languages.SV;
                // El idioma a continuación aparece en la documentación pero no está en la librería
                //case CodigosIdiomas.UD:
                //    return NewsAPI.Constants.Languages.UD;
                case CodigosIdiomas.ZH:
                    return NewsAPI.Constants.Languages.ZH;
                default:
                    // Si el código no coincide (o es ES), en español
                    return NewsAPI.Constants.Languages.ES;
            }
        }

        private NewsAPI.Constants.SortBys GetOrden(OrdenBusqueda? orden)
        {
            switch (orden)
            {
                case OrdenBusqueda.popularidad:
                    return NewsAPI.Constants.SortBys.Popularity;
                case OrdenBusqueda.fechaPublicacion:
                    return NewsAPI.Constants.SortBys.PublishedAt;
                default:
                    // Si lo ingresado no es nada (o es Relevancia), va relevancia
                    return NewsAPI.Constants.SortBys.Relevancy;
            }
        }
    }
}
