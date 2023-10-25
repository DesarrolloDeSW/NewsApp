using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace NewsApp.UltimasVisitas
{
    public interface IUltimaVisitaAppService : ICrudAppService<UltimaVisitaDto, int>
    {
    }
}
