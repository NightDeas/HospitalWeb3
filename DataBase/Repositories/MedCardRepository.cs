using DataBase.Entities;
using DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories
{
    public class MedCardRepository : Interfaces.IDefaultRepository<MedCard>, IMedCardRepository
    {
        public Context Context { get; set; }

        public MedCardRepository(Context context)
        {
            Context = context;
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await Context.MedCards.AnyAsync(x => x.Id == id);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MedCard> Get(int id)
        {
            return await Context.MedCards.FirstAsync(x => x.Id == id);
        }

        public async Task<int> Post(MedCard entity)
        {
            await Context.MedCards.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Update(int id, MedCard entity)
        {
            await Get(id);
            entity.PatientId = entity.PatientId;
            entity.Created = entity.Created;
            entity.Updated = DateTime.Now;
        }

        public async Task<MedCard> GetByPatient(int patientId)
        {
            return await Context.MedCards.FirstAsync(x => x.PatientId == patientId);
        }
    }
}
