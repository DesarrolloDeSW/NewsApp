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

namespace NewsApp.Alertas
{

    public class EfCoreAlertaRepository
    : EfCoreRepository<NewsAppDbContext, Alerta, int>,
        IAlertaRepository
    {
        public EfCoreAlertaRepository(
            IDbContextProvider<NewsAppDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Alerta> FindByCadenaAsync(string cadenaBusqueda)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(alerta => alerta.CadenaBusqueda == cadenaBusqueda);
        }

        public async Task<List<Alerta>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    lista => lista.CadenaBusqueda.Contains(filter)
                    )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}

