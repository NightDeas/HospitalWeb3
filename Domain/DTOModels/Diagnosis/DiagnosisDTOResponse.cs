using Domain.DTOModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOModels.Diagnosis
{
    public class DiagnosisDTOResponse : DefaultEntity, IModelSingleConvert<DiagnosisDTOResponse, DataBase.Entities.Diagnosis>
    {
        public string Name { get; set; }
        public DataBase.Entities.Diagnosis ConvertToDAL(DiagnosisDTOResponse model)
        {
            var entity = new DataBase.Entities.Diagnosis()
            {
                Id = model.Id,
                Name = model.Name,
            };
            return entity;
        }

        public DiagnosisDTOResponse ConvertToDTO(DataBase.Entities.Diagnosis model)
        {
            var entity = new DiagnosisDTOResponse()
            {
                Id = model.Id,
                Name = model.Name,
            };
            return entity;
        }

    }
}
