using Api.Controllers.Interfaces;
using Domain.DTOModels.Diagnosis;
using Domain.DTOModels.Hospitalization;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisController : Controller, IDefaultController<DiagnosisDTORequest>
    {
        DiagnosisService Service { get; set; }

        public DiagnosisController(DiagnosisService service)
        {
            Service = service;
        }

        [HttpGet("any/{id}")]
        public async Task<IActionResult> AnyAsync(int id)
        {
            var result = await Service.AnyAsync(id);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await Service.Delete(id);
            return Ok();
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (!await Service.AnyAsync(id))
                return NotFound();
            var result = await Service.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DiagnosisDTORequest entity)
        {
            var result = await Service.Post(entity);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, DiagnosisDTORequest entity)
        {
            if (!await Service.AnyAsync(id))
                return NotFound();
            var result = await Service.Post(entity);
            return Ok(result);
        }

       
    }
}
