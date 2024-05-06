﻿using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Nortwind.Entities.Concrete
{
    public class Role:IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}