using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOModels.Insurance
{
    public class InsurancePolicyDTOResponse : DefaultEntity, Interfaces.IModelSingleConvert<InsurancePolicyDTOResponse, InsurancePolicy>
    {
        public string Number { get; set; }
        public DateTime End { get; set; }
        public int PatientId { get; set; }

        public InsurancePolicy ConvertToDAL(InsurancePolicyDTOResponse model)
        {
            var DALModel = new InsurancePolicy()
            {
                End = model.End,
                Number = model.Number,
                PatientId = model.PatientId,
            };
            return DALModel;
        }

        public InsurancePolicyDTOResponse ConvertToDTO(InsurancePolicy model)
        {
            var DTOModel = new InsurancePolicyDTOResponse()
            {
                End = model.End,
                Number = model.Number,
                PatientId = model.PatientId,
            };
            return DTOModel;
        }
    }
}
