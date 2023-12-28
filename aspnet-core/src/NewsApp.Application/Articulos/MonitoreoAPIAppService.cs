using Microsoft.AspNetCore.Identity;
using NewsApp.Articulos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using NewsApp.API;
using NewsApp.Permissions;
using Microsoft.AspNetCore.Authorization;

namespace NewsApp.Articulos
{
    public class MonitoreoAPIAppService : NewsAppAppService, IMonitoreoAPIAppService
    {
        private readonly IRepository<AccesoAPI,int> _monitoreoRepository;
        private readonly MonitoreoAPIManager _monitoreoAPIManager;
        private readonly UserManager<IdentityUser> _userManager;

        public MonitoreoAPIAppService(
            IRepository<AccesoAPI,int> monitoreoRepository,
            MonitoreoAPIManager monitoreoAPIManager, UserManager<IdentityUser> userManager)
        {
            _monitoreoRepository = monitoreoRepository;
            _monitoreoAPIManager = monitoreoAPIManager;
            _userManager = userManager;
        }

        public async Task<TimeSpan> GetTiempoPromedioAsync()
        {
            var accesos = await _monitoreoRepository.GetListAsync(includeDetails: true);
            var tiempo = await _monitoreoAPIManager.CalcularTiempoPromedio(accesos);

            return tiempo;
        }
        public async Task<long> GetCantidadTotalAccesosAsync()
        {
            return await _monitoreoRepository.GetCountAsync();
        }

        public async Task<float> GetPorcentajeExitoAsync()
        {
            var accesos = await _monitoreoRepository.GetListAsync();
            return await _monitoreoAPIManager.CalcularPorcentajeExito(accesos);
        }

        public async Task<long> GetCantidadAccesosUsuarioAsync(Guid usuarioId)
        {
            var accesos = await _monitoreoRepository.GetListAsync(acc => acc.UsuarioId == usuarioId);
            return accesos.Count;
        }

        [Authorize(NewsAppPermissions.Monitoreo.Default)]
        public async Task<ICollection<AccesoAPIDto>> GetAccesosAPIAsync()
        {
            var listas = await _monitoreoRepository.GetListAsync(includeDetails: true);

            return ObjectMapper.Map<ICollection<AccesoAPI>, ICollection<AccesoAPIDto>>(listas);
        }
    }

}
