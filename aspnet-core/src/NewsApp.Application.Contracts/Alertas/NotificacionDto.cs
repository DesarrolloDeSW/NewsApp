using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NewsApp.Alertas
{
    public class NotificacionDto : EntityDto<int>
    {
        public DateTime FechaEnvio { get; set; }

        public string CadenaBusqueda { get; set; }

        public Guid UsuarioId { get; set; }

        public bool Leida { get; set; }
    }
}
