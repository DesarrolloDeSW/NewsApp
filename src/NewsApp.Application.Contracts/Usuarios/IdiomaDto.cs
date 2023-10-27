using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NewsApp.Usuarios
{
    public class IdiomaDto : EntityDto<int>
    {
        public string Nombre { get; set; }
        public string Codigo  { get; set; }
    }
}
