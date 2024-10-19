using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Entities;
namespace Domain.DTOModels.Patient
{
    public class PatientDTOResponseTableData : DTOModels.Interfaces.IThreeDalModelsConvertToDTO<PatientDTOResponseTableData, DataBase.Entities.Patient, DataBase.Entities.MedCard, InsurancePolicy>
    {
        public int Id { get; set; }
        public string FullName => $"{LastName} {FirstName} {Patronymic}";
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Passport { get; set; }
        public string Address { get; set; }
        public string? WorkAddress { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public string Genre { get; set; }
        public string InsuranceNumber { get; set; }
        public DateTime InsuranceDateEnd { get; set; }
        public DateTime MedCardCreated { get; set; }

        public PatientDTOResponseTableData CovnertToDTO(DataBase.Entities.Patient modelOne, DataBase.Entities.MedCard modelTwo, InsurancePolicy modelThree)
        {
            var DTOModel = new PatientDTOResponseTableData()
            {
                Id = modelOne.Id,
                LastName = modelOne.LastName,
                FirstName = modelOne.FirstName,
                DateOfBirth = modelOne.DateOfBirth,
                Address = modelOne.Address,
                Email = modelOne.Email,
                Genre = DataBase.Enums.GenreService.GetGenreString(modelOne.GenreId),
                InsuranceDateEnd = modelThree.End,
                InsuranceNumber = modelThree.Number,
                Passport = modelOne.Passport,
                Patronymic = modelOne.Patronymic,
                Telephone = modelOne.Telephone,
                WorkAddress = modelOne.WorkAddress,
                MedCardCreated = modelTwo.Created,
            };
            return DTOModel;
        }
    }
}
