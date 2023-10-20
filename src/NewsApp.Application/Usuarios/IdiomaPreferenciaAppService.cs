using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace NewsApp.Usuarios
{
    public class IdiomaPreferenciaAppService : CrudAppService<IdiomaPreferencia, IdiomaPreferenciaDto, int>, IIdiomaPreferenciaAppService
    {
        public IdiomaPreferenciaAppService(IRepository<IdiomaPreferencia, int> repository) : base(repository)
        { }
    }
}
