using DataBase.Entities;
using Domain.DTOModels.MedCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IMedCardService
    {
        Task Update(int id, MedCardDTORequestUpdateTime model);
        Task<MedCardDTOResponse> GetByPatient(int patientId);

    }
}
