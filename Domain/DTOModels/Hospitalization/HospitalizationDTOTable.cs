using DataBase.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOModels.Hospitalization
{
    public class HospitalizationDTOTable : Interfaces.IDoubleDALModelsConvertToDTO<HospitalizationDTOTable, DataBase.Entities.Hospitalization, DataBase.Entities.Patient>
    {
        public string FullName { get; set; }
        public string Code { get; set; }
        public bool IsRejection { get; set; }
        public bool IsCancel { get; set; }
        public string ReasonRejection { get; set; }
        public DateTime Date { get; set; }

        public HospitalizationDTOTable ConvertToDTO(DataBase.Entities.Hospitalization modelOne, DataBase.Entities.Patient modelTwo)
        {
            var DTOModel = new HospitalizationDTOTable()
            {
                FullName = modelTwo.FirstName,
                Code = modelOne.Code,
                Date = modelOne.Date,
                IsCancel = modelOne.IsCancel,
                IsRejection = modelOne.IsRejection,
                ReasonRejection = modelOne.ReasonRejection
            };
            return DTOModel;
        }
    }
}
