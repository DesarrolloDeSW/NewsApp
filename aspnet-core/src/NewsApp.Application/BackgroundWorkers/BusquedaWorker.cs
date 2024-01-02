using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NewsApp.Alertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Threading;


namespace NewsApp.BackgroundWorkers
{
    public class BusquedaWorker : AsyncPeriodicBackgroundWorkerBase
    {
        public BusquedaWorker (
            AbpAsyncTimer timer, IServiceScopeFactory serviceScopeFactory) : base ( timer, serviceScopeFactory)
        {
            Timer.Period = 300000;
        }

        protected async override Task DoWorkAsync (
            PeriodicBackgroundWorkerContext workerContext)
        {
            Logger.LogInformation("Comenzando la Búsqueda de Alertas");

            var alertaRepository = workerContext
                .ServiceProvider
                .GetRequiredService<IAlertaRepository> ();

            var alertaAppService = workerContext 
                .ServiceProvider 
                .GetService<IAlertaAppService> ();

            var alertasActivas = await alertaRepository.GetListAsync (al => al.Activa == true);
            
            foreach (var alerta in alertasActivas)
            {
                await alertaAppService.GestionarAlertaAsync(alerta.Id);
            }

            Logger.LogInformation("Completada la Búsqueda de Alertas");
        }

    }
}
