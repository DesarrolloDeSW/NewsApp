using Microsoft.AspNetCore.Identity;
using NewsApp.Articulos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Emailing;
using Volo.Abp.Identity;

namespace NewsApp.Alertas
{
    public class AlertaAppService : NewsAppAppService, IAlertaAppService
    {
        private readonly IAlertaRepository _alertaRepository;
        private readonly IRepository<Notificacion,int> _notificacionRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AlertaManager _alertaManager;
        private readonly IArticulosAppService _articulosAppService;
        private readonly IEmailSender _emailSender;
        private readonly IIdentityUserRepository _identityUserRepository;

        public AlertaAppService(
            IAlertaRepository alertaRepository,
            AlertaManager alertaManager,
            UserManager<IdentityUser> userManager,
            IRepository<Notificacion, int> notificacionRepository,
            IArticulosAppService articulosAppService,
            IEmailSender emailSender,
            IIdentityUserRepository identityUserRepository
            )

        {
            _alertaRepository = alertaRepository;
            _userManager = userManager;
            _alertaManager = alertaManager;
            _notificacionRepository = notificacionRepository;
            _articulosAppService = articulosAppService;
            _emailSender = emailSender;
            _identityUserRepository = identityUserRepository;
        }

        public async Task<AlertaDto> PostAlertaAsync(string cadenaBusqueda)
        {
            var userGuid = CurrentUser.Id.GetValueOrDefault();
            var usuario = await _userManager.FindByIdAsync(userGuid.ToString());
            var alerta = await _alertaManager.CreateAsync(cadenaBusqueda, usuario);
            var respuesta = await _alertaRepository.InsertAsync(alerta, autoSave: true);
            return ObjectMapper.Map<Alerta, AlertaDto>(respuesta);
        }

        public async Task<NotificacionDto> PostNotificacionAsync(int alertaId)
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

        public async Task<ICollection<AlertaDto>> GetAlertasAsync()
        {
            var userGuid = CurrentUser.Id.GetValueOrDefault();
            var alertas = await _alertaRepository.GetListAsync(al => al.UsuarioId == userGuid, includeDetails: true);

            return ObjectMapper.Map<ICollection<Alerta>, ICollection<AlertaDto>>(alertas);
        }

        public async Task MarcarNotificacionesComoLeidas()
        {
            var userGuid = CurrentUser.Id.GetValueOrDefault();
            var notificaciones = await _notificacionRepository.GetListAsync(not => not.UsuarioId == userGuid);
            await _alertaManager.MarcarNotificacionesComoLeidas(notificaciones);
        }

        public async Task GestionarAlertaAsync(int alertaId)
        {
            var alerta = await _alertaRepository.FindAsync(alertaId);
            var articulos = await _articulosAppService.GetBusquedaApiNewsAsync(alerta.CadenaBusqueda, null, null);

            if (articulos.Count != 0) 
            {
                alerta.Desactivar();
                await PostNotificacionAsync(alertaId);
                await EnviarMailAsync(alerta.UsuarioId, alerta.CadenaBusqueda);
            }
        }

        public async Task EnviarMailAsync(Guid usuarioId, string cadenaBusqueda)
        {
            try
            {
                var usuario = await _identityUserRepository.GetAsync(usuarioId);
                var direccion = await _userManager.GetEmailAsync(usuario);

                if (!string.IsNullOrWhiteSpace(direccion))
                {
                    Console.WriteLine($"Intentando enviar correo electrónico a: {direccion}");

                    await _emailSender.SendAsync(
                        direccion,     // target email address
                        "Nuevos resultados sobre " + cadenaBusqueda,         // subject
                        $@"
                Se han encontrado resultados sobre tu búsqueda de {cadenaBusqueda}.
                Entrá a la aplicación y realizá la búsqueda para consultarlos!
                "  // email body
                    );

                    Console.WriteLine("Correo electrónico enviado exitosamente.");
                }
                else
                {
                    Console.WriteLine("La dirección de correo electrónico es nula o está en blanco.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo electrónico: {ex.Message}");
                // También puedes imprimir la pila de llamadas para obtener más detalles
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}