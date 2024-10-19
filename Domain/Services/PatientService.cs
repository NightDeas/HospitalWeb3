using DataBase.Entities;
using DataBase.Repositories;
using DataBase.Repositories.Interfaces;
using Domain.DTOModels.Patient;
using Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class PatientService : IDefaultService<PatientDTORequest, PatientDTOResponse>, IPatientService
    {
        public required PatientRepostiory PatientReposiory;
        public required MedCardRepository MedCardReposiory;
        public required InsurancePolicyRepository InsurancePolicyReposiory;

        public PatientService(PatientRepostiory reposiory, MedCardRepository medCardReposiory, InsurancePolicyRepository insuranceReposiory)
        {
            PatientReposiory = reposiory;
            MedCardReposiory = medCardReposiory;
            InsurancePolicyReposiory = insuranceReposiory;
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await PatientReposiory.AnyAsync(id);
        }

        public async Task Delete(int id)
        {
            await PatientReposiory.Delete(id);
        }

        public async Task<PatientDTOResponse> Get(int id)
        {
            var DalModel = await PatientReposiory.Get(id);
            var DTOModel = new PatientDTOResponse().ConvertToDTO(DalModel);
            return DTOModel;
        }

        public async Task<List<PatientDTOResponseTableData>> GetTableData()
        {
            var DALPatients = await PatientReposiory.GetDataTable();
            List<PatientDTOResponseTableData> result = DALPatients.Select(x => new PatientDTOResponseTableData().CovnertToDTO(x, x.MedCard, x.InsurancePolicy)).ToList();
            return result;
        }
        public async Task<List<PatientDTOResponseTableData>> GetTableData(string parametr)
        {
            var DALPatients = await PatientReposiory.GetDataTable(parametr);

            List<PatientDTOResponseTableData> result = new();
            foreach (var d in DALPatients)
            {
                var medCard = await MedCardReposiory.GetByPatient(d.Id);
                var insurance = await InsurancePolicyReposiory.GetByPatient(d.Id);
                result.Add(new PatientDTOResponseTableData().CovnertToDTO(d, medCard, insurance));
            }
            return result;
        }

        public async Task<int> Post(PatientDTORequest entity)
        {
            var DALModel = entity.ConvertToDAL(entity);
            return await PatientReposiory.Post(DALModel);
        }

        public async Task Update(int id, PatientDTORequest entity)
        {
            await PatientReposiory.Update(id, entity.ConvertToDAL(entity));
        }
    }
}
