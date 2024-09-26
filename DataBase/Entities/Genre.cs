using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class Genre : DefaultEntity
    {
        public string Name { get;set; }

        public virtual ICollection<Patient> Patient { get; set; }
    }
}
