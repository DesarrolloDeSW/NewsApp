﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace NewsApp.Noticias;

public class Fuente : Entity<int>
{
    public string Nombre { get; set; }
}