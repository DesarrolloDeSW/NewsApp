using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace NewsApp.Alertas
{
    public class AlertaAppService : NewsAppAppService, IAlertaAppService
    {
        private readonly IAlertaRepository _alertaRepository;
        private readonly IRepository<Notificacion,int> _notificacionRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AlertaManager _alertaManager;

        public AlertaAppService(
            IAlertaRepository alertaRepository,
            AlertaManager alertaManager,
            UserManager<IdentityUser> userManager, IRepository<Notificacion,int> notificacionRepository)

        {
            _alertaRepository = alertaRepository;
            _userManager = userManager;
            _alertaManager = alertaManager;
            _notificacionRepository = notificacionRepository;
        }

        public async Task<AlertaDto> PostAlertaAsync(string cadenaBusqueda)
        {
            var userGuid = CurrentUser.Id.GetValueOrDefault();
            var usuario = await _userManager.FindByIdAsync(userGuid.ToString());
            var alerta = await _alertaManager.CreateAsync(cadenaBusqueda, usuario);
            var respuesta = await _alertaRepository.InsertAsync(alerta, autoSave: true);
            return ObjectMapper.Map<Alerta, AlertaDto>(respuesta);
        }

        public async Task<NotificacionDto> PostNotificacionDto(int alertaId)
        {
            var alerta = await _alertaRepository.FindAsync(alertaId);
            var notif = await _alertaManager.CreateNotificacionAsync(alerta);
            var respuesta = await _notificacionRepository.InsertAsync(notif, autoSave: true);
            return ObjectMapper.Map<Notificacion, NotificacionDto>(respuesta);
        }

        public async Task<ICollection<NotificacionDto>> GetNotificacionesAsync()
        {
            var userGuid = CurrentUser.Id.GetValueOrDefault();
            var notificaciones = await _notificacionRepository.GetListAsync(not => not.UsuarioId == userGuid, includeDetails: true);

            return ObjectMapper.Map<ICollection<Notificacion>, ICollection<NotificacionDto>>(notificaciones);
        }

        public async Task MarcarNotificacionesComoLeidas()
        {
            var userGuid = CurrentUser.Id.GetValueOrDefault();
            var notificaciones = await _notificacionRepository.GetListAsync(not => not.UsuarioId == userGuid, includeDetails: true);
            await _alertaManager.MarcarNotificacionesComoLeidas(notificaciones);
        }

    }
}