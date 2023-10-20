using NewsApp.Listas;
using NewsApp.Noticias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace NewsApp.Usuarios
{
    public class Usuario : Entity<int>
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public ICollection<Lista> Listas {get; set;}
        public Pais Pais { get; set; }
        public ICollection<IdiomaPreferencia> Idiomas { get; set; }

    }

}
