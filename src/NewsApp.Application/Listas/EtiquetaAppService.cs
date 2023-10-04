using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace NewsApp.Listas
{
    public class EtiquetaAppService : CrudAppService<Etiqueta, EtiquetaDto, int>, IEtiquetaAppService
    {
        public EtiquetaAppService(IRepository<Etiqueta, int> repository) : base(repository)
        { }
    }
}
