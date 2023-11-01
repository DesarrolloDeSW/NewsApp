using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;


namespace NewsApp.UltimasVisitas
{
    public class UltimaVisitaDto : EntityDto<int>
    {
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public string UrlNoticia { get; set; }
    }
}
