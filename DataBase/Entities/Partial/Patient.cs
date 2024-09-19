using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public partial class Patient
    {
        public string FullName => $"{LastName} {FirstName} {Patronymic}";
    }
}
