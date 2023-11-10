using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsApp.Noticias;
using Volo.Abp.Domain.Entities;


namespace NewsApp.Usuarios
{
    public class UltimaVisita : Entity<int>
    {
        public DateTime Fecha { get; set; }
        public Usuario Usuario { get; set; }
        public string UrlNoticia { get; set; }

    }
}
