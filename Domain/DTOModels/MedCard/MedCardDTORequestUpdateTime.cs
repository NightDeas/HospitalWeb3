using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOModels.MedCard
{
    public class MedCardDTORequestUpdateTime : Interfaces.IModelSingleConvert<MedCardDTORequestUpdateTime, DataBase.Entities.MedCard>
    {
        public DateTime Updated { get; set; }
        public DataBase.Entities.MedCard ConvertToDAL(MedCardDTORequestUpdateTime model)
        {
            var DALModel = new DataBase.Entities.MedCard()
            {
                Updated = model.Updated,
            };
            return DALModel;
        }

        public MedCardDTORequestUpdateTime ConvertToDTO(DataBase.Entities.MedCard model)
        {
            var DTOModel = new MedCardDTORequestUpdateTime()
            {
                Updated = model.Updated
            };
            return DTOModel;
        }
    }
}
