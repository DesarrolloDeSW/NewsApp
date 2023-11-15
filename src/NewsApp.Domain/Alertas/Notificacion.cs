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
        public string Mensaje { get; set; }

        public DateTime FechaEnvio { get; set; }

        public Alerta Alerta { get; set; }

        public IdentityUser UsuarioDestinatario
        {
            get { return Alerta.Usuario; }
        }
    }

}
