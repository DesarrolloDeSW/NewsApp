using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace NewsApp.Noticias
{
    public interface INoticiaAppService: ICrudAppService<NoticiaDto,int>
    {
    }
}
