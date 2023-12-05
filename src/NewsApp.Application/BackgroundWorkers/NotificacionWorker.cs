using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers;

namespace NewsApp.BackgroundWorkers
{
    public class NotificacionWorker : BackgroundWorkerBase
    {
        public override Task StartAsync(CancellationToken cancellationToken = default)
        {
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken = default)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
