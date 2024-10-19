using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        public Task<List<Patient>> GetDataTable();
        public Task<List<Patient>> GetDataTable(string textSearch);
    }
}
