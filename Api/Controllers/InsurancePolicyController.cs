using Api.Controllers.Interfaces;
using Domain.DTOModels.Insurance;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancePolicyController : Controller, IDefaultController<Domain.DTOModels.Insurance.InsurancePolicyDTORequest>
    {
        public InsurancePolicyService Service { get; set; }

        public InsurancePolicyController(InsurancePolicyService service)
        {
            Service = service;
        }
        [HttpGet("any/{id:int}")]
        public async Task<IActionResult> AnyAsync(int id)
        {
            var result = await Service.AnyAsync(id);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await Service.AnyAsync(id))
                return NotFound();
            await Service.Delete(id);
            return Ok();
        }
        [HttpGet("get/{id:int}")]

        public async Task<IActionResult> Get(int id)
        {
            if (!await Service.AnyAsync(id))
                return NotFound();
            var result = await Service.Get(id);
            return Ok(result);
        }
        [HttpPost]

        public async Task<IActionResult> Post(InsurancePolicyDTORequest entity)
        {
            var result = await Service.Post(entity);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, InsurancePolicyDTORequest entity)
        {
            if (!await Service.AnyAsync(id))
                return NotFound();
            await Service.Update(id, entity);
            return Ok();
        }
        [HttpGet("patient/{patientId:int}")]
        public async Task<IActionResult> GetByPatientId(int patientId)
        {
            var result = await Service.GetByPatient(patientId);
            return Ok(result);
        }
    }
}
