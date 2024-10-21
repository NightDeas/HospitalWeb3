using DataBase.Repositories;
using Domain.DTOModels.Hospitalization;
using Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class HospitalizationService : IDefaultService<HospitalizationDTORequest, HospitalizationDTOResponse>
    {
        HospitalizationRepository Repository;

        public HospitalizationService(HospitalizationRepository repository)
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

        public async Task<HospitalizationDTOResponse> Get(int id)
        {
            return new HospitalizationDTOResponse().ConvertToDTO(await Repository.Get(id));
        }

        public async Task<int> Post(HospitalizationDTORequest entity)
        {
            return await Repository.Post(entity.ConvertToDAL(entity));
        }

        public Task Update(int id, HospitalizationDTORequest entity)
        {
            return Repository.Update(id, entity.ConvertToDAL(entity));
        }
    }
}
