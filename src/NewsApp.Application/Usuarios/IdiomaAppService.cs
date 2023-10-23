using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace NewsApp.Usuarios
{
    public class IdiomaAppService : CrudAppService<Idioma, IdiomaDto, int>, IIdiomaAppService
    {
        public IdiomaAppService(IRepository<Idioma, int> repository) : base(repository)
        { }
    }
}
