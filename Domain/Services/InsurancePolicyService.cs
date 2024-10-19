using DataBase.Repositories;
using Domain.DTOModels.Insurance;
using Domain.Services.Interfaces;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class InsurancePolicyService : IDefaultService<InsurancePolicyDTORequest, InsurancePolicyDTOResponse>, IInsurancePolicyService
    {
        public InsurancePolicyRepository Repository;

        public InsurancePolicyService(InsurancePolicyRepository repository)
        {
            Repository = repository;
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await Repository.AnyAsync(id);
        }

        public async Task Delete(int id)
        {
            await Repository.Delete(id);
        }

        public async Task<bool> Expired(int id)
        {
           return await Repository.Expired(id);
        }

        public async Task<InsurancePolicyDTOResponse> Get(int id)
        {
            return new InsurancePolicyDTOResponse().ConvertToDTO(await Repository.Get(id));
        }

        public async Task<InsurancePolicyDTOResponse> GetByPatient(int patientId)
        {
            return new InsurancePolicyDTOResponse().ConvertToDTO(await Repository.GetByPatient(patientId));
        }

        public async Task<int> Post(InsurancePolicyDTORequest entity)
        {
            return await Repository.Post(entity.ConvertToDAL(entity));
        }

        public async Task Update(int id, InsurancePolicyDTORequest entity)
        {
            await Repository.Update(id, entity.ConvertToDAL(entity));
        }
    }
}
