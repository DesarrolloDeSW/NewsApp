using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NewsApp.Noticias
{
    public class FuenteDto : EntityDto<int>
    {
        public string Nombre { get; set; }
    }
}
