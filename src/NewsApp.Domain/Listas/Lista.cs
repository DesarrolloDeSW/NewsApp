using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using NewsApp.Noticias;   // ESTÁ BIEN???

namespace NewsApp.Listas;

public class Lista : Entity<int>
{
    public string Nombre { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string Descripcion { get; set; }

    public bool Alerta { get; set; }

    public ICollection<Noticia> Noticias { get; set; }
    public ICollection<Lista> Listas { get; set; }
    public ICollection<Etiqueta> Etiquetas { get; set; }

}
