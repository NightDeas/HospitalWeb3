using DataBase.Entities;
using DataBase.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories
{
    public class HospitalizationRepository : IDefaultRepository<Hospitalization>
    {
        public Task<bool> AnyAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Hospitalization> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Post(Hospitalization entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Hospitalization entity)
        {
            throw new NotImplementedException();
        }
    }
}
