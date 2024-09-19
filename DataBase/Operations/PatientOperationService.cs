using DataBase.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Operations
{
	public class PatientOperationService : IDefaultOperationDbEntity<Entities.Patient>
	{
		Context Context;

		public PatientOperationService(Context context)
		{
			Context = context;
		}

		public async Task<int> AddAsync(Patient Entity)
		{
			Context.Patients.Add(Entity);
			await Context.SaveChangesAsync();
			return Entity.Id;
		}

		public Task DeleteAsync(Patient Entity)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

        public Task<Patient> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Patient>> GetAll()
        {
			return await Context.Patients.ToListAsync();
        }

        public Task<List<Patient>> GetPatientsAsync()
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(Patient Entity)
		{
			throw new NotImplementedException();
		}
	}
}
