using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NewsApp.Alertas

{
    public class AlertaYaExiste : BusinessException
    {
        public AlertaYaExiste(string Cadena)
            : base(NewsAppDomainErrorCodes.AlertaYaExiste)
        {
            WithData("cadena", Cadena);
        }
    }
}
