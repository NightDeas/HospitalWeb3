﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class Hospitalization : DefaultEntity
    {
        public Hospitalization()
        {
            Create = DateTime.Now;
        }

        public int PatientId { get; set; }
        public string Code { get; set; }
        public bool IsRejection { get; set; }
        public bool IsCancel { get; set; }
        public string? ReasonRejection { get; set; }
        public DateTime Date { get; set; }
        public DateTime Create { get; set; }

        public virtual Patient Patient { get; set; }

    }
}
