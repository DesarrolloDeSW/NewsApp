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
    }

}
