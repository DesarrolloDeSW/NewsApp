using Microsoft.EntityFrameworkCore;
using NewsApp.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace NewsApp.Listas
{

    public class EfCoreListaRepository
    : EfCoreRepository<NewsAppDbContext, Lista, int>,
        IListaRepository
    {
        public EfCoreListaRepository(
            IDbContextProvider<NewsAppDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Lista> FindByNameAsync(string nombre)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(lista => lista.Nombre== nombre);
        }

        public async Task<List<Lista>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    lista => lista.Nombre.Contains(filter)
                    )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
