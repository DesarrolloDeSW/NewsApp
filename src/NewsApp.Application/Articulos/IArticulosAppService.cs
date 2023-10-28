using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace NewsApp.Articulos
{
    public interface IArticulosAppService : IApplicationService
    {
        string GetArticulos(string cadena);
    }
}
