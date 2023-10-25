using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace NewsApp.Alertas
{
    public interface INotificacionAppService : ICrudAppService<NotificacionDto, int>
    {
    }
}
