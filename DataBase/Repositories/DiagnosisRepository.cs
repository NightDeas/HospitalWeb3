using DataBase.Entities;
using DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories
{
    public class DiagnosisRepository : IDefaultRepository<Diagnosis>
    {
        Context Context { get; set; }

        public DiagnosisRepository(Context context)
        {
            Context = context;
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await Context.Diagnoses.AnyAsync(x=> x.Id == id);
        }

        public async Task Delete(int id)
        {
            var diag = await Get(id);
            Context.Diagnoses.Remove(diag);
            await Context.SaveChangesAsync();
        }

        public async Task<Diagnosis> Get(int id)
        {
            return await Context.Diagnoses.FirstAsync(x => x.Id == id);
        }

        public async Task<int> Post(Diagnosis entity)
        {
            await Context.Diagnoses.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity.Id;
        }

        public Task Update(int id, Diagnosis entity)
        {
            throw new NotImplementedException();
        }
    }
}
