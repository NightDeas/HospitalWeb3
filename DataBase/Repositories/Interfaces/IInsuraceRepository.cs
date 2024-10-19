using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories.Interfaces
{
    public interface IInsuraceRepository
    {
        Task<bool> Expired(int id);
        Task<InsurancePolicy> GetByPatient(int patientId);
    }
}
