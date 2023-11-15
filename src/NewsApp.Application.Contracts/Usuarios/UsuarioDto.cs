using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using NewsApp.Listas;

namespace NewsApp.Usuarios
{
    public class UsuarioDto :EntityDto<Guid>
    {
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? NombreUsuario { get; set; }

        public string? Email { get; set; }

    }
}
