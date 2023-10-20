using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace NewsApp.Usuarios
{
    public class Pais : Entity<int>
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }
}
