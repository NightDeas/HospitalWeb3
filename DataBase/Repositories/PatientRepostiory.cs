using DataBase.Entities;
using DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repositories
{
    public class PatientRepostiory : IDefaultRepository<Patient>, IPatientRepository
    {
        public Context Context { get; set; }

        public PatientRepostiory(Context context)
        {
            Context = context;
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await Context.Patients.AnyAsync(x => x.Id == id);
        }

        public async Task<Patient> Get(int id)
        {
            return await Context.Patients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Post(Patient entity)
        {
            await Context.Patients.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Update(int id, Patient entity)
        {
            var model = await Context.Patients.FirstAsync(x => x.Id == id);

            model.Id = id;
            model.FirstName = entity.FirstName;
            model.Address = entity.Address;
            model.DateOfBirth = entity.DateOfBirth;
            model.Email = entity.Email;
            model.GenreId = entity.GenreId;
            model.Patronymic = entity.Patronymic;
            model.LastName = entity.LastName;
            model.Passport = entity.Passport;
            model.Photo = entity.Photo;
            model.WorkAddress = entity.WorkAddress;
            model.Telephone = entity.Telephone;

            Context.Patients.Update(model);
            await Context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var model = await Context.Patients.FirstAsync(x => x.Id == id);
            Context.Patients.Remove(model);
            await Context.SaveChangesAsync();
        }

        public async Task<List<Patient>> GetDataTable()
        {
            var patients = await Context.Patients
                .Include(x => x.InsurancePolicy)
                .Include(x => x.MedCard)
                .ToListAsync();
            return patients;

        }

        public async Task<List<Patient>> GetDataTable(string parametr)
        {
            bool parseDate = DateTime.TryParse(parametr, out DateTime dateTime);
            var patients = await Context.Patients
               .Include(x => x.InsurancePolicy)
               .Include(x => x.MedCard)
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
        (parseDate && x.DateOfBirth.Date == dateTime)).ToListAsync();
            return patients;
        }
    }
}
