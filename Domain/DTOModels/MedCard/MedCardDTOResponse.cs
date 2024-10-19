using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOModels.MedCard
{
    public class MedCardDTOResponse : DefaultEntity, Interfaces.IModelSingleConvert<MedCardDTOResponse, DataBase.Entities.MedCard>
    {
        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public int PatientId { get; set; }

        public DataBase.Entities.MedCard ConvertToDAL(MedCardDTOResponse model)
        {
            var DALModel = new DataBase.Entities.MedCard()
            {
                Id = model.Id,
                Created = model.Created,
                PatientId = model.PatientId,
                Updated = model.Updated,
            };
            return DALModel;
        }

        public MedCardDTOResponse ConvertToDTO(DataBase.Entities.MedCard model)
        {
            var DTOModel = new MedCardDTOResponse()
            {
                Id = model.Id,
                Created = model.Created,
                PatientId = model.PatientId,
                Updated = model.Updated,
            };
            return DTOModel;
        }
    }
}
