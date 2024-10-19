using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories.Interfaces
{
    public interface IDefaultRepository<DALModel>
    {
        Task<bool> AnyAsync(int id);
        Task<DALModel> Get(int id);
        Task<int> Post(DALModel entity);
        Task Update(int id, DALModel entity);
        Task Delete(int id);
    }
}
