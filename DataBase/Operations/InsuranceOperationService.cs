using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Operations
{
    public class InsuranceOperationService : IDefaultOperationDbEntity<InsurancePolicy>
	{
		Context context;

		public InsuranceOperationService(Context context)
		{
			this.context = context;
		}

		public async Task<int> AddAsync(InsurancePolicy Entity)
		{
			context.Add(Entity);
			await context.SaveChangesAsync();
			return Entity.Id;
		}

		public Task DeleteAsync(InsurancePolicy Entity)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

        public Task<InsurancePolicy> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<InsurancePolicy>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<InsurancePolicy>> GetPatientsAsync()
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(InsurancePolicy Entity)
		{
			throw new NotImplementedException();
		}
	}
}
