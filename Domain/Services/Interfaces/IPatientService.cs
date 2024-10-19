using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IPatientService
    {
        Task<List<DTOModels.Patient.PatientDTOResponseTableData>> GetTableData();
        Task<List<DTOModels.Patient.PatientDTOResponseTableData>> GetTableData(string parametr);
    }
}
