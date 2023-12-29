using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Volo.Abp.Application.Dtos;

namespace NewsApp.Articulos
{
    public class AccesoAPIDto: EntityDto<int>
    {
        public Guid? UsuarioId { get; set; }
        public TimeSpan TiempoTotal { get; set; }
        public DateTime TiempoInicio { get; set; }
        public DateTime TiempoFin { get; set; }
        public ErrorCodes? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
