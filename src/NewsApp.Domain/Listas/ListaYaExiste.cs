using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NewsApp.Listas
{
    public class ListaYaExiste : BusinessException
    {
        public ListaYaExiste(string Nombre)
            : base(NewsAppDomainErrorCodes.ListaYaExiste)
        {
            WithData("nombre", Nombre);
        }
    }
}
