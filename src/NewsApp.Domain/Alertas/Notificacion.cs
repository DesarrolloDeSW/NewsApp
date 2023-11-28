using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace NewsApp.Alertas
{
    public class Notificacion : Entity<int>
    {
        public DateTime FechaEnvio { get; set; }

        public string CadenaBusqueda { get; set; }

        public Guid UsuarioId { get; set; }

        public bool Leida { get; set; }

        public void MarcarComoLeida()
        {
            this.Leida = true;
        }
    }

}
