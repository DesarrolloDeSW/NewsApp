using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using NewsApp.Noticias;
using Volo.Abp.Identity;

namespace NewsApp.Listas;

public class Lista : Entity<int>
{
    public string Nombre { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? Descripcion { get; set; }

    public bool Alerta { get; set; }

    public ICollection<Noticia> Noticias { get; set; }

    public ICollection<Lista> Listas { get; set; }

    public ICollection<string> Etiquetas { get; set; }
    public Guid UsuarioId { get; set; }

    public Lista ()
    {
        this.Listas = new List<Lista>();
        this.Etiquetas = new List<string>();
        this.Noticias = new List<Noticia>();
    }

    public void CambiarNombre(string NombreNuevo)
    { this.Nombre = NombreNuevo; }

    public void CambiarDescripcion(string DescripcionNueva)
    { this.Descripcion = DescripcionNueva; }
}

