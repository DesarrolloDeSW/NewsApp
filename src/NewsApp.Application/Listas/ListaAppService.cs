using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace NewsApp.Listas
{
    public class ListaAppService : CrudAppService<Lista, ListaDto, int>, IListaAppService
    {
        public ListaAppService(IRepository<Lista, int> repository) : base(repository)
        { }
    }
}
