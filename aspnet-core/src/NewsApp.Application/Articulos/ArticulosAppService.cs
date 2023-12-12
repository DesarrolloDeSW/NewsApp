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
using Microsoft.AspNetCore.Identity;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.ObjectMapping;
using NewsAPI.Models;
using NewsApp.Listas;

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
        public async Task<ICollection<NoticiaDto>> GetBusquedaApiNewsAsync(string cadena, CodigosIdiomas? idioma, OrdenBusqueda? ordenarPor)

        {
            var _gestorNewsAPI = new GestorNewsAPI();

            var inicio = DateTime.Now;
            var articulos = await _gestorNewsAPI.GetNoticiasAsync(cadena, idioma, ordenarPor);
            var fin = DateTime.Now;

            var userGuid = CurrentUser.Id.GetValueOrDefault();
            var usuario = await _userManager.FindByIdAsync(userGuid.ToString());

            Error error = articulos.Item2;
            var codigoError = ErrorCodes.TodoBien;
            string mensajeError = null;

            if (error != null)
            {
                codigoError = ConvertToNewsAppErrorCode(error.Code);
                mensajeError = error.Message;
            }

            var acceso = await _monitoreoAPIManager.CreateAsync(usuario, inicio, fin, codigoError, mensajeError);

            await _monitoreoRepository.InsertAsync(acceso, autoSave: true);

            return ObjectMapper.Map<ICollection<ArticuloDto>, ICollection<NoticiaDto>>(articulos.Item1);
        }

        public static ErrorCodes ConvertToNewsAppErrorCode(NewsAPI.Constants.ErrorCodes errorCode)
        {
            return (NewsApp.Articulos.ErrorCodes)errorCode;
        }
    }
}