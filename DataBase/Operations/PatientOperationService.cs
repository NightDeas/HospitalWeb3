using DataBase.Entities;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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

        public async Task<Patient> Get(int id)
        {
			throw new NotImplementedException();
        }

        public async Task<List<Patient>> GetAll()
        {
			return await Context.Patients
				.Include(x=> x.Genre)
				.ToListAsync();
        }

        public Task<List<Patient>> GetPatientsAsync()
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(Patient Entity)
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// Получить всю доступную информацию о пациенте, которая включает:
		/// основная информация(Patient), мед карта(medCard), полис(insurancePolicy)
		/// </summary>
		/// <returns></returns>
		public async Task<List<PatientFullData>> GetFullData()
		{
			IPatientDataOperation<MedCard> medCardService = new Operations.MedCardOperationService(Context);
			IPatientDataOperation<InsurancePolicy> insuranceOperationService = new Operations.InsuranceOperationService(Context);
			List<PatientFullData> patientFullData = new List<PatientFullData>();
			var patients = await GetAll();
			foreach (var patient in patients)
			{
				var medcard = (patient.Id);
                patientFullData.Add(new(patient, await insuranceOperationService.GetByPatient(patient.Id), await medCardService.GetByPatient(patient.Id)));
			}
			return patientFullData;
		}
	}
}
