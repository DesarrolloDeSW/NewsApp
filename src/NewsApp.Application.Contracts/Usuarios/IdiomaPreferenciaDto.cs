using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NewsApp.Usuarios
{
    public class IdiomaPreferenciaDto : EntityDto<int>
    {
        public Idioma Idioma { get; set; }
        public int Prioridad  { get; set; }
    }
}
