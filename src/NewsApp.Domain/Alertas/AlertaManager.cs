using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;

namespace NewsApp.Alertas
{
    public class AlertaManager: DomainService
    {
        private readonly IAlertaRepository _alertaRepository;

        public AlertaManager(IAlertaRepository AlertaRepository)
        {
            _alertaRepository = AlertaRepository;
        }

        public async Task<Alerta> CreateAsync (string cadenaBusqueda, IdentityUser usuario)
        {
            Alerta alerta = null;

            var alertaExistente = await _alertaRepository.FindByCadenaAsync(cadenaBusqueda);
            if (alertaExistente != null && alertaExistente.UsuarioId == usuario.Id)
            {
                throw new AlertaYaExiste(cadenaBusqueda);
            }

            alerta = new Alerta
            {
                FechaCreacion = DateTime.Today,
                Activa = true,
                CadenaBusqueda = cadenaBusqueda,
                UsuarioId = usuario.Id
            };

            return alerta;
        }

        public async Task<Notificacion> CreateNotificacionAsync(Alerta alerta)
        {
            if (alerta==null)
            {
                throw new AlertaNoExiste();
            }            
            Notificacion notif = null;

            var idUsuario = alerta.UsuarioId;
            var cadena = alerta.CadenaBusqueda;

            notif = new Notificacion
            {
                FechaEnvio = DateTime.Today,
                Leida = false,
                CadenaBusqueda = cadena,
                UsuarioId = idUsuario
            };

            return notif;
        }

        public async Task<List<Notificacion>> MarcarNotificacionesComoLeidas(List<Notificacion> notificaciones)
        {
            foreach (var notificacion in notificaciones)
            {
                notificacion.MarcarComoLeida();
            }

            return notificaciones;
        }
    }
}
