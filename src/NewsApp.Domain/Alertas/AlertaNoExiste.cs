using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NewsApp.Alertas

{
    public class AlertaNoExiste : BusinessException
    {
        public AlertaNoExiste()
            : base(NewsAppDomainErrorCodes.AlertaNoExiste)
        { 
        }
    }
}
