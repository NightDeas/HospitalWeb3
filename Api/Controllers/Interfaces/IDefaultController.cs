using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Interfaces
{
    public interface IDefaultController<RequestModel>
    {
        Task<IActionResult> AnyAsync(int id);
        Task<IActionResult> Get(int id);
        Task<IActionResult> Post(RequestModel entity);
        Task<IActionResult> Update(int id, RequestModel entity);
        Task<IActionResult> Delete(int id);
    }
}
