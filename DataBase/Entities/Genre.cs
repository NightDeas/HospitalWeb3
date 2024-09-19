﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class Genre : DefaultEntity
    {
        public string Name { get;set; }

        public virtual Patient Patient { get; set; }
    }
}
