using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;


namespace NewsApp.UltimasVisitas
{
    public class UltimaVisitaAppService : CrudAppService<UltimaVisita, UltimaVisitaDto, int>, IUltimaVisitaAppService
    {
        public UltimaVisitaAppService(IRepository<UltimaVisita, int> repository) : base(repository)

        { }
    }
}
