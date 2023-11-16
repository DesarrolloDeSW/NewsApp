using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace NewsApp.Listas
{

    public interface IListaRepository : IRepository<Lista, int>
    {
        Task<Lista> FindByNameAsync(string name);

        Task<List<Lista>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
