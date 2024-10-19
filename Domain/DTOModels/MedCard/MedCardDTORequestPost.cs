using DataBase.Entities;
using Microsoft.EntityFrameworkCore.Scaffolding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOModels.MedCard
{
    public class MedCardDTORequestPost : Interfaces.IModelSingleConvert<MedCardDTORequestPost, DataBase.Entities.MedCard>
    {
        public int PatientId { get; set; }
        public DataBase.Entities.MedCard ConvertToDAL(MedCardDTORequestPost model)
        {
            var DALModel = new DataBase.Entities.MedCard()
            {
                PatientId = model.PatientId
            };
            return DALModel;
        }

        public MedCardDTORequestPost ConvertToDTO(DataBase.Entities.MedCard model)
        {
            var DTOModel = new MedCardDTORequestPost()
            {
                PatientId = model.PatientId,
            };
            return DTOModel;
        }
    }
}
