using DataBase.Entities;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
			return await Context.Patients
				.Include(x => x.Genre)
				.FirstAsync(x => x.Id == id);
        }

        public async Task<List<Patient>> GetAll()
        {
			return await Context.Patients
				.AsNoTracking()
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

        public async Task<List<PatientFullData>> GetFullData(string parametr)
        {
			bool parseDate = DateTime.TryParse(parametr, out DateTime dateTime);
            var fullDataPatient = await Context.Patients
    .Include(x => x.Genre)
    .Include(x => x.MedCard)
    .Include(x => x.InsurancePolicy)
    .Where(x =>
        x.LastName.Contains(parametr) ||
        x.FirstName.Contains(parametr) ||
        x.Patronymic.Contains(parametr) ||
        (parseDate && x.MedCard != null && x.MedCard.Created.Date == dateTime) ||
        (parseDate && x.MedCard != null && x.MedCard.Updated.Date == dateTime) ||
        x.Passport.Contains(parametr) ||
        (x.InsurancePolicy != null && x.InsurancePolicy.Number.Contains(parametr)) ||
        (parseDate && x.InsurancePolicy != null && x.InsurancePolicy.End == dateTime) ||
        x.WorkAddress.Contains(parametr) ||
        x.Address.Contains(parametr) ||
        (x.Genre != null && x.Genre.Name.Contains(parametr)) ||
        x.Telephone.Contains(parametr) ||
        (parseDate && x.DateOfBirth.Date == dateTime)
    ).AsNoTracking().ToListAsync();
            var fulldata = PatientFullData.ToFullData(fullDataPatient);
			return fulldata;
        }
    }
}
