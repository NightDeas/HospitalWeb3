using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Operations
{
    public class MedCardOperationService : IDefaultOperationDbEntity<MedCard>, IPatientDataOperation<MedCard>
	{
		Context context;

		public MedCardOperationService(Context context)
		{
			this.context = context;
		}

		public async Task<int> AddAsync(MedCard Entity)
		{
			context.MedCards.Add(Entity);
			await context.SaveChangesAsync();
			return Entity.Id;
		}

		public Task DeleteAsync(MedCard Entity)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

        public async Task<MedCard> Get(int id)
        {
            return await context.MedCards.FirstAsync(c => c.Id == id);
        }

     


        public Task<List<MedCard>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<MedCard>> GetPatientsAsync()
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(MedCard Entity)
		{
			throw new NotImplementedException();
		}

        public async Task<MedCard> GetByPatient(int patientId)
        {
            return await context.MedCards.AsNoTracking().FirstAsync(c => c.PatientId == patientId);
        }
    }
}
