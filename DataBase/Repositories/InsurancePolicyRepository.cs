using DataBase.Entities;
using DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories
{
    public class InsurancePolicyRepository : Interfaces.IDefaultRepository<InsurancePolicy>, IInsuraceRepository
    {
        Context Context;

        public InsurancePolicyRepository(Context context)
        {
            Context = context;
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await Context.InsurancePolicies.AnyAsync(x => x.Id == id);
        }

        public async Task Delete(int id)
        {
            var model = await Context.InsurancePolicies.FirstAsync(x => x.Id == id);
            Context.InsurancePolicies.Remove(model);
            await Context.SaveChangesAsync();
        }

        public async Task<bool> Expired(int id)
        {
            return (await Context.InsurancePolicies.FirstAsync(x => x.Id == id)).End < DateTime.Now;
        }

        public async Task<InsurancePolicy> Get(int id)
        {
            return await Context.InsurancePolicies.FirstAsync(x => x.Id == id);
        }

        public async Task<InsurancePolicy> GetByPatient(int patientId)
        {
            return await Context.InsurancePolicies.FirstAsync(x => x.PatientId == patientId);
        }

        public async Task<int> Post(InsurancePolicy entity)
        {
            await Context.InsurancePolicies.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Update(int id, InsurancePolicy entity)
        {
            var model = await Context.InsurancePolicies.FirstAsync(x => x.Id == id);
            
            model.Number = entity.Number;
            model.PatientId = entity.PatientId;
            model.End = entity.End;

            await Context.SaveChangesAsync();
        }
    }
}
