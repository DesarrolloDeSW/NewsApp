using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using NewsApp.Articulos;

namespace NewsApp.API
{
    public class AccesoAPI : Entity<int>
    {
        public Guid? UsuarioId { get; set; }
        public TimeSpan TiempoTotal { get; set; }
        public DateTime TiempoInicio { get; set;}
        public DateTime TiempoFin { get; set; }
        public ErrorCodes? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
