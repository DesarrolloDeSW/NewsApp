using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NewsApp.Alertas
{
    public class NotificacionDto : EntityDto<int>
    {
        public string Mensaje { get; set; }

        public DateTime FechaEnvio { get; set; }

        public AlertaDto Alerta { get; set; }

        public Guid UsuarioId { get; set; }

        public bool Leida { get; set; }
    }
}
