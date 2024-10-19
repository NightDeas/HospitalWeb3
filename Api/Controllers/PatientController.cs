using Api.Controllers.Interfaces;
using DataBase.Entities;

using Domain.DTOModels.Insurance;
using Domain.DTOModels.MedCard;
using Domain.DTOModels.Patient;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : Controller, IDefaultController<Domain.DTOModels.Patient.PatientDTORequest>, IPatientController
    {
        public PatientService PatientService { get; set; }
        public MedCardService MedCardService { get; set; }
        public InsurancePolicyService InsurancePolicyService { get; set; }

        public PatientController(PatientService service, MedCardService medCardService, InsurancePolicyService insurancePolicyService)
        {
            PatientService = service;
            MedCardService = medCardService;
            InsurancePolicyService = insurancePolicyService;
        }

        [HttpGet("any/{id:int}")]
        public async Task<IActionResult> AnyAsync(int id)
        {
            var result = await PatientService.AnyAsync(id);
            return Ok(result);
        }
        [HttpGet("get/{id:int}")]
        [ProducesResponseType(typeof(PatientDTOResponse), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            if (!await PatientService.AnyAsync(id))
                return NotFound();
            var model = await PatientService.Get(id);
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> Post(PatientDTORequest entity)
        {
            var result = await PatientService.Post(entity);
            await MedCardService.Post(new()
            {
                PatientId = result
            });
            await InsurancePolicyService.Post(new()
            {
                End = entity.InsuranceEnd,
                Number = entity.InsuranceNumber,
                PatientId = result,
            });
            return Ok(result);
        }
        [HttpPut("{id}/{entity}")]
        public async Task<IActionResult> Update(int id, PatientDTORequest entity)
        {
            await PatientService.Update(id, entity);
            InsurancePolicyDTORequest insuranceDTO = new()
            {
                End = entity.InsuranceEnd,
                Number = entity.InsuranceNumber,
            };
            int insuranceId = (await InsurancePolicyService.GetByPatient(entity.Id)).Id;
            await InsurancePolicyService.Update(insuranceId, insuranceDTO);

            MedCardDTORequestUpdateTime medCardDTO = new()
            {
                Updated = DateTime.Now
            };
            int medCardId = (await MedCardService.GetByPatient(entity.Id)).Id;
            await MedCardService.Update(medCardId, medCardDTO);

            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await PatientService.Delete(id);
            return Ok();  
        }
        [HttpGet("tables/getAll")]
        public async Task<IActionResult> GetTableData()
        {
            var result = await PatientService.GetTableData();
            return Ok(result);
        }
        [HttpGet("tables/get/{parametr}")]
        public async Task<IActionResult> GetTableData(string parametr)
        {
            var result = await PatientService.GetTableData(parametr);
            return Ok(result);
        }
    }
}
