using DataBase.Entities;
using DataBase.Repositories;
using Domain.DTOModels.Hospitalization;
using Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class HospitalizationService : IDefaultService<HospitalizationDTORequest, HospitalizationDTOResponse>
    {
        HospitalizationRepository Repository { get; set; }

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

        public async Task<List<DTOModels.Hospitalization.HospitalizationDTOResponseTable>> GetTableData(string? parametr)
        {
            var data = await Repository.GetTableData(parametr);
            var result = data.Select(x => new HospitalizationDTOResponseTable().ConvertToDTO(x.Patient, x)).ToList();
            return result;
        }
    }
}
