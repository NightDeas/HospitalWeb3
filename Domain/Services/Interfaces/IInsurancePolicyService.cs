using DataBase.Entities;
using Domain.DTOModels.Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IInsurancePolicyService
    {
        Task<bool> Expired(int id);
        Task<InsurancePolicyDTOResponse> GetByPatient(int patientId);

    }
}
