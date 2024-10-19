using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Interfaces
{
    public interface IPatientController
    {
        Task<IActionResult> GetTableData();
    }
}
