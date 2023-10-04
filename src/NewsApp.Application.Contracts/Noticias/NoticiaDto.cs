using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NewsApp.Noticias
{
    public class NoticiaDto:EntityDto<int>
    {
        public string Titulo { get; set; }

        public string Autor { get; set; }

        public string Descripcion { get; set; }

        public string Url { get; set; }

        public string Contenido { get; set; }

        public string UrlImagen { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public FuenteDto Fuente { get; set; }
    }
}
