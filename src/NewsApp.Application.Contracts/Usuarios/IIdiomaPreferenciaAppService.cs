using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace NewsApp.Usuarios
{
    public interface IIdiomaPreferenciaAppService : ICrudAppService<IdiomaPreferenciaDto, int>
    {
    }
}
