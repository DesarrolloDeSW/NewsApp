using NewsApp.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace NewsApp.Alertas
{
    public class Notificacion : Entity<int>
    {
        public string Mensaje { get; set; }

        public DateTime FechaEnvio { get; set; }

        public Alerta Alerta { get; set; }

        public Usuario UsuarioDestinatario
        {
            get { return Alerta.Usuario; }
        }
    }

}
