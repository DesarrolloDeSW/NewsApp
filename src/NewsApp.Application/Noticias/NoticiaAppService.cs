using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace NewsApp.Noticias
{
    public class NoticiaAppService : CrudAppService<Noticia,NoticiaDto,int>, INoticiaAppService
    {
        public NoticiaAppService(IRepository<Noticia,int> repository):base(repository)

        { }
    }
}
