﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace NewsApp.Listas
{
    public class Etiqueta:Entity<int>
    {
        public string CadenaClave { get; set; }
    }
}
