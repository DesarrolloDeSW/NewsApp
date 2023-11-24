using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsApp.Listas
{
    public class CreateListaDto
    {
        [Required]
        public string Nombre { get; set; }

        public string? Descripcion { get; set; }

        public int? ParentId { get; set; }
    }
}
