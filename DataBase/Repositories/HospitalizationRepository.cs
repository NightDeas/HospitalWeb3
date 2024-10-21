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
    public class HospitalizationRepository : IDefaultRepository<Hospitalization>
    {
        Context Context { get; set; }

        public HospitalizationRepository(Context context)
        {
            Context = context;
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await Context.Hospitalizations.AnyAsync(x => x.Id == id);
        }

        public async Task Delete(int id)
        {
            var hosp = Get(id);
            Context.Remove(hosp);
            await Context.SaveChangesAsync();
        }

        public async Task<Hospitalization> Get(int id)
        {
            var hosp = await Context.Hospitalizations.FirstAsync(x => x.Id == id);
            return hosp;
        }

        public async Task<int> Post(Hospitalization entity)
        {
            await Context.Hospitalizations.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Update(int id, Hospitalization entity)
        {
            var hosp = await Get(id);

            hosp.ReasonRejection = entity.ReasonRejection;
            hosp.IsRejection = entity.IsRejection;
            hosp.PatientId = entity.PatientId;
            hosp.Code = entity.Code;
            hosp.Date = entity.Date;
            hosp.IsCancel = entity.IsCancel;
            hosp.Create = entity.Create;

            await Context.SaveChangesAsync();

        }
    }
}
