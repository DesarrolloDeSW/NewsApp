using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using NewsApp.Noticias; 

namespace NewsApp.Listas;

public class Lista : Entity<int>
{
    public string Nombre { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string Descripcion { get; set; }

    public bool Alerta { get; set; }

    public ICollection<Noticia> Noticias { get; set; }

    public ICollection<Lista> Listas { get; set; }

    public ICollection<string> Etiquetas { get; set; }

    public void AgregarNoticia(Noticia unaNoticia)
    {
        Noticias.Add(unaNoticia);
    }

    public void EliminarNoticia(Noticia unaNoticia)
    {
        if (Noticias.Contains(unaNoticia))
        {
            Noticias.Remove(unaNoticia);
        }
    }

    public void AgregarEtiqueta(string unaEtiqueta)
    {
        Etiquetas.Add(unaEtiqueta);
    }

    public void EliminarEtiqueta(string unaEtiqueta)
    {
        if (Etiquetas.Contains(unaEtiqueta))
        {
            Etiquetas.Remove(unaEtiqueta);
        }
    }

}

