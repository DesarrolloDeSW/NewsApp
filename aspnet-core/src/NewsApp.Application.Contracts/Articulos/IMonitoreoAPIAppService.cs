using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace NewsApp.Articulos
{
        public interface IMonitoreoAPIAppService : IApplicationService
    {
        Task<TimeSpan> GetTiempoPromedioAsync();
        Task<long> GetCantidadTotalAccesosAsync();
        Task<float> GetPorcentajeExitoAsync();
        Task<long> GetCantidadAccesosUsuarioAsync(Guid usuarioId);
    }
    
}
