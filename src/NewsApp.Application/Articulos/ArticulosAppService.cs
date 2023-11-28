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
using Microsoft.AspNetCore.Identity;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace NewsApp.Articulos
{
    public class ArticulosAppService : NewsAppAppService, IArticulosAppService
    {
        private readonly IRepository<AccesoAPI, int> _monitoreoRepository;
        private readonly MonitoreoAPIManager _monitoreoAPIManager;
        private readonly UserManager<IdentityUser> _userManager;

        public ArticulosAppService(
            IRepository<AccesoAPI, int> monitoreoRepository,
            MonitoreoAPIManager monitoreoAPIManager, UserManager<IdentityUser> userManager)
        {
            _monitoreoRepository = monitoreoRepository;
            _monitoreoAPIManager = monitoreoAPIManager;
            _userManager = userManager;
        }
        public async Task<ICollection<NoticiaDto>> GetNoticiasApiNewsAsync(string cadena, CodigosIdiomas? idioma, OrdenBusqueda? ordenarPor)

        {
            var _gestorNewsAPI = new GestorNewsAPI();
            var inicio = DateTime.Now;
            var articulos = await _gestorNewsAPI.GetNoticiasAsync(cadena, idioma, ordenarPor);
            var fin = DateTime.Now;
            var userGuid = CurrentUser.Id.GetValueOrDefault();
            var usuario = await _userManager.FindByIdAsync(userGuid.ToString());
            var acceso = await _monitoreoAPIManager.CreateAsync(usuario, inicio, fin, null, 200);
            await _monitoreoRepository.InsertAsync(acceso, autoSave: true);
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