﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace NewsApp.Listas
{
    public interface IEtiquetaAppService : ICrudAppService<EtiquetaDto, int>
    {
    }
}
