using DataBase.Entities;
using Domain.DTOModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOModels.Diagnosis
{
    public class DiagnosisDTORequest : IModelSingleConvert<DiagnosisDTORequest, DataBase.Entities.Diagnosis>
    {
        public string Name { get; set; }

        public DataBase.Entities.Diagnosis ConvertToDAL(DiagnosisDTORequest model)
        {
            var entity = new DataBase.Entities.Diagnosis()
            {
                Name = model.Name,
            };
            return entity;
        }

        public DiagnosisDTORequest ConvertToDTO(DataBase.Entities.Diagnosis model)
        {
            var entity = new DiagnosisDTORequest()
            {
                Name = model.Name,
            };
            return entity;
        }
    }
}
