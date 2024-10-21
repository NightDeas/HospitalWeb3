using DataBase.Entities;
using Domain.DTOModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOModels.Hospitalization
{
    public class HospitalizationDTORequest : DefaultEntity, IModelSingleConvert<HospitalizationDTORequest, DataBase.Entities.Hospitalization>
    {
        public int PatientId { get; set; }
        public string Code { get; set; }
        public bool IsRejection { get; set; }
        public bool IsCancel { get; set; }
        public string ReasonRejection { get; set; }
        public DateTime Date { get; set; }

        public DataBase.Entities.Hospitalization ConvertToDAL(HospitalizationDTORequest model)
        {
            var newModel = new DataBase.Entities.Hospitalization()
            {
                Code = model.Code,
                Date = model.Date,
                PatientId = model.PatientId,
                IsCancel = model.IsCancel,
                IsRejection = model.IsRejection,
                ReasonRejection = model.ReasonRejection,
                Id = model.Id,
            };
            return newModel;
        }

        public HospitalizationDTORequest ConvertToDTO(DataBase.Entities.Hospitalization model)
        {
            var newModel = new HospitalizationDTORequest()
            {
                Code = model.Code,
                Date = model.Date,
                PatientId = model.PatientId,
                IsCancel = model.IsCancel,
                IsRejection = model.IsRejection,
                ReasonRejection = model.ReasonRejection,
                Id = model.Id,
            };
            return newModel;
        }
    }
}
