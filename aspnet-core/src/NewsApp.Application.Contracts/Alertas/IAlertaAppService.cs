﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace NewsApp.Alertas
{
    public interface IAlertaAppService: IApplicationService
    {
        Task<AlertaDto> PostAlertaAsync(string cadenaBusqueda);
        Task<NotificacionDto> PostNotificacionAsync(int alertaId);
        Task<ICollection<NotificacionDto>> GetNotificacionesAsync();
        Task<ICollection<AlertaDto>> GetAlertasAsync();
        Task MarcarNotificacionesComoLeidas();
        Task GestionarAlertaAsync(int alertaId);
        Task EnviarMailAsync(Guid usuarioId, string cadenaBusqueda);
    }
}
