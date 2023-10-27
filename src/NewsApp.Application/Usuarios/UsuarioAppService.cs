using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace NewsApp.Usuarios
{
    public class UsuarioAppService : CrudAppService<Usuario, UsuarioDto, int>, IUsuarioAppService
    {
        public UsuarioAppService(IRepository<Usuario, int> repository):base(repository)

        { }
    }
}
