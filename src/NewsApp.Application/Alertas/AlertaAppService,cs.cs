using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace NewsApp.Alertas
{
    public class AlertaAppService : CrudAppService<Alerta, AlertaDto, int>, IAlertaAppService
    {
        public AlertaAppService(IRepository<Alerta, int> repository) : base(repository)

        { }
    }
}
