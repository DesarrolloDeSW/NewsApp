using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace NewsApp.Usuarios
{
    public class IdiomaPreferencia : Entity<int>
    {
        public Idioma Idioma { get; set; }
        public int Prioridad { get; set; }
    }
}
