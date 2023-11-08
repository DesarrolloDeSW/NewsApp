using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using NewsApp.Articulos;

namespace NewsApp.Usuarios
{
    public class Idioma : Entity<int>
    {
        public string Nombre { get; set; }
        public CodigosIdiomas Codigo { get; set; }
    }

}
