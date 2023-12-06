using NewsApp.Listas;
using System;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NewsApp.Articulos;

namespace NewsApp.API
{
    public class MonitoreoAPIManager : DomainService
    {
        private readonly IRepository<AccesoAPI, int> _monitoreoRepository;

        public MonitoreoAPIManager(IRepository<AccesoAPI, int> MonitoreoRepository)
        {
            _monitoreoRepository = MonitoreoRepository;
        }
        public async Task<AccesoAPI> CreateAsync(IdentityUser usuario, DateTime tiempoInicio, DateTime tiempoFin, ErrorCodes? errorCode, string? errorMessage)
        {
            AccesoAPI acceso = null;
            TimeSpan tiempoTotal = tiempoFin - tiempoInicio;
            Guid? idUsuario = null;
            if (usuario != null)
            { idUsuario = usuario.Id; }

            acceso = new AccesoAPI{ 
                TiempoInicio = tiempoInicio,
                TiempoFin = tiempoFin,
                TiempoTotal = tiempoTotal,
                UsuarioId = idUsuario, 
                ErrorCode = errorCode,
                ErrorMessage = errorMessage};

            return acceso;
        }

        public async Task<TimeSpan> CalcularTiempoPromedio(List<AccesoAPI> accesos)
        {
            TimeSpan sumaTiempo = new TimeSpan();

            foreach (var acceso in accesos)
            {
                sumaTiempo += acceso.TiempoTotal;
            }

            return sumaTiempo / accesos.Count;
        }

        public async Task<float> CalcularPorcentajeExito(List<AccesoAPI> accesos)
        {
            var cant_exito = 0;
            var cant_total = accesos.Count;
            float porcentaje = 0;
            if (cant_total!=0)
            {
                foreach (var acceso in accesos)
                {
                    if (acceso.ErrorMessage == null)
                    {
                        cant_exito += 1;
                    }
                }
                porcentaje = cant_exito * 100 / cant_total;
            }

            return porcentaje;
        }
    }
}
