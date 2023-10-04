using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NewsApp.Listas
{
    public class EtiquetaDto : EntityDto<int>
    {
        public string CadenaClave { get; set; }
    }
}
