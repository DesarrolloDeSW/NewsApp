using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using NewsApp.Noticias;

namespace NewsApp.Listas
{
    public class ListaDto : EntityDto<int>
    {
        public string Nombre { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string Descripcion { get; set; }

        public bool Alerta { get; set; }

        public ICollection<NoticiaDto> Noticias { get; set; }
        public ICollection<ListaDto> Listas { get; set; }
        public ICollection<EtiquetaDto> Etiquetas { get; set; }
    }
}
