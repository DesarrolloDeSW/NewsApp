using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace NewsApp.Alertas
{
    public class Alerta : Entity<int>
    {
        public DateTime FechaCreacion { get; set; }

        public bool Activa { get; set; }

        public ICollection<string> Etiquetas { get; set; }

        public IdentityUser Usuario { get; set; }

        public void Activar()
        {
            Activa = true;
        }

        public void Desactivar()
        {
            Activa = false;
        }

        // método que agregue etiquetas de una lista dada (si no están ya)

    }

}
