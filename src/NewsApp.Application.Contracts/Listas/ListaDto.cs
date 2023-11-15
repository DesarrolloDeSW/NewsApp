using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using NewsApp.Noticias;
using NewsApp.Usuarios;

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
        public ICollection<string> Etiquetas { get; set; }
        public Guid UsuarioId { get; set; } 
    }
}
