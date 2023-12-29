using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NewsApp.Listas
{
    public class NoticiaDto : EntityDto<int>
    {
        public string Titulo { get; set; }

        public string Autor { get; set; }

        public string Descripcion { get; set; }

        public string Url { get; set; }

        public string UrlImagen { get; set; }

        public string Contenido { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public string Fuente { get; set; }

        public bool Visto { get; set; }
    }
}
