using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IDefaultService<RequestModel, ResponseModel>
    {
        Task<bool> AnyAsync(int id);
        Task<ResponseModel> Get(int id);
        Task<int> Post(RequestModel entity);
        Task Update(int id, RequestModel entity);
        Task Delete(int id);
    }
}
