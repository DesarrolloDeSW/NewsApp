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

        public ICollection<string> Etiquetas { get; set; }

        public int UsuarioId { get; set; }

    }
}
