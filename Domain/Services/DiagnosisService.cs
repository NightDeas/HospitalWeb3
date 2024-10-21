using DataBase.Repositories;
using Domain.DTOModels.Diagnosis;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class DiagnosisService : IDefaultService<DiagnosisDTORequest, DiagnosisDTOResponse>
    {
        DiagnosisRepository Repository;

        public DiagnosisService(DiagnosisRepository repository)
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

        public async Task<DiagnosisDTOResponse> Get(int id)
        {
            return new DiagnosisDTOResponse().ConvertToDTO(await Repository.Get(id));
        }

        public async Task<int> Post(DiagnosisDTORequest entity)
        {
            return await Repository.Post(entity.ConvertToDAL(entity));
        }

        public async Task Update(int id, DiagnosisDTORequest entity)
        {
            await Repository.Update(id, entity.ConvertToDAL(entity));
        }
    }
}
