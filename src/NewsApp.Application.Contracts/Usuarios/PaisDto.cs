using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NewsApp.Usuarios
{
    public class PaisDto : EntityDto<int>
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }

    }
}
