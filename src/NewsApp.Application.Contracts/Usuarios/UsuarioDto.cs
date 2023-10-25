using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using NewsApp.Listas;
using NewsApp.UltimasVisitas;


namespace NewsApp.Usuarios
{
    public class UsuarioDto : EntityDto<int>
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string NombreUsuario { get; set; }

        public string Email { get; set; }

        public string Foto { get; set; }

        public ICollection<ListaDto> Listas { get; set; }

        public ICollection<UltimaVisitaDto> UltimasVisitas { get; set; }

        public int PaisId { get; set; }

        public int IdiomaId { get; set; }
    }
}
