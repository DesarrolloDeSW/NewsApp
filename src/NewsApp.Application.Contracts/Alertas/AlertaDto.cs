using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NewsApp.Alertas
{
    public class AlertaDto : EntityDto<int>
    {
        public DateTime FechaCreacion { get; set; }

        public bool Activa { get; set; }

        public string CadenaBusqueda { get; set; }

        public Guid UsuarioId { get; set; }

    }
}
