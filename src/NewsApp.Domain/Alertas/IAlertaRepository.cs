using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace NewsApp.Alertas
{

    public interface IAlertaRepository : IRepository<Alerta, int>
    {
        Task<Alerta> FindByCadenaAsync(string name);

        Task<List<Alerta>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}