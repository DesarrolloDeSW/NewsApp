using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System.Text.Json;

namespace NewsApp.API
{
    public class GestorNewsAPI
    {
        NewsApiClient newsApiClient;

        // Ponemos API key
        public GestorNewsAPI()
        {
            newsApiClient = new NewsApiClient("58548a921ea745e78548a561dacaa277"); 
        }

        // Método que devuelve string con JSON de noticias dada una cadena
        public string GetNoticias(string cadena)
        {
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = cadena,
                SortBy = SortBys.Popularity,
                // Language = GetIdioma(),
                Language=Languages.EN,
                From = new DateTime (2023,10,15)
            }); ; 

            if (articlesResponse.Status == Statuses.Ok)
            {
                return JsonSerializer.Serialize(articlesResponse.Articles);
            }

            throw new Exception("Error: " + articlesResponse.Status);
        }


    }
}
