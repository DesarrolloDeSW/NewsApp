using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace NewsApp.Noticias;

public class Noticia : Entity<int>
{
    public string Titulo { get; set; }

    public string Autor { get; set; }

    public string Descripcion { get; set; }

    public string Url { get; set; }
    public string UrlImagen { get; set; }

    public string Contenido { get; set; }

    public DateTime FechaPublicacion { get; set; }

    public string Fuente { get; set; }

}
