using Azure.Core.Pipeline;
using DataBase.Repositories;
using Domain.DTOModels.MedCard;
using Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class MedCardService : IMedCardService, IDefaultService<MedCardDTORequestPost, MedCardDTOResponse>
    {
        public MedCardRepository Repository;

        public MedCardService(MedCardRepository repository)
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

        public async Task<MedCardDTOResponse> Get(int id)
        {
            var DALModel = await Repository.Get(id);
            var DTOModel = new MedCardDTOResponse().ConvertToDTO(DALModel);
            return DTOModel;
        }

        public async Task<MedCardDTOResponse> GetByPatient(int patientId)
        {
            var DALModel = await Repository.GetByPatient(patientId);
            var DTOModel = new MedCardDTOResponse().ConvertToDTO(DALModel);
            return DTOModel;
        }

        public async Task<int> Post(MedCardDTORequestPost entity)
        {
            var result = await Repository.Post(entity.ConvertToDAL(entity));
            return result;
        }

        public Task Update(int id, MedCardDTORequestPost entity)
        {
            throw new NotImplementedException();
        }

        public async Task Update(int id, MedCardDTORequestUpdateTime model)
        {
            await Repository.Update(id, model.ConvertToDAL(model));
        }
    }
}
