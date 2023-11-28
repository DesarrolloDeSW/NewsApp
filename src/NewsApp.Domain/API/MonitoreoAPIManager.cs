using NewsApp.Listas;
using System;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace NewsApp.API
{
    public class MonitoreoAPIManager : DomainService
    {
        private readonly IRepository<AccesoAPI, int> _monitoreoRepository;

        public MonitoreoAPIManager(IRepository<AccesoAPI, int> MonitoreoRepository)
        {
            _monitoreoRepository = MonitoreoRepository;
        }
        public async Task<AccesoAPI> CreateAsync(IdentityUser usuario, DateTime tiempoInicio, DateTime tiempoFin, string? error, int codigoHTTP)
        {
            AccesoAPI acceso = null;
            TimeSpan tiempoTotal = tiempoFin - tiempoInicio;

            acceso = new AccesoAPI{ 
                TiempoInicio = tiempoInicio,
                TiempoFin = tiempoFin,
                TiempoTotal = tiempoTotal,
                UsuarioId = usuario.Id, 
                Error = error,
                CodigoHTTP = codigoHTTP };

            return acceso;
        }
    }
}
