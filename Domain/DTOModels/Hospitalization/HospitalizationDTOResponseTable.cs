using DataBase.Entities;
using Domain.DTOModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOModels.Hospitalization
{
    public class HospitalizationDTOResponseTable : DTOModels.Interfaces.IDoubleDALModelsConvertToDTO<HospitalizationDTOResponseTable ,DataBase.Entities.Patient, DataBase.Entities.Hospitalization>
    {
        public int Id { get; set; }
        public string PatientFullName { get; set; }
        public string Code { get; set; }
        public bool IsRejection { get; set; }
        public bool IsCancel { get; set; }
        public string ReasonRejection { get; set; }
        public DateTime Date { get; set; }

        public HospitalizationDTOResponseTable ConvertToDTO(DataBase.Entities.Patient modelOne, DataBase.Entities.Hospitalization modelTwo)
        {
            var model = new HospitalizationDTOResponseTable()
            {
                Id = modelTwo.Id,    
                PatientFullName = modelOne.FullName,
                Date = modelTwo.Date,
                Code = modelTwo.Code,
                IsCancel = modelTwo.IsCancel,
                IsRejection = modelTwo.IsRejection,
                ReasonRejection = modelTwo.ReasonRejection,
            };
            return model;
        }
    }
}
