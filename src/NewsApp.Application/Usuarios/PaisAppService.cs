using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace NewsApp.Usuarios
{
    public class PaisAppService : CrudAppService<Pais, PaisDto, int>, IPaisAppService
    {
        public PaisAppService(IRepository<Pais, int> repository) : base(repository)
        { }
    }
}
