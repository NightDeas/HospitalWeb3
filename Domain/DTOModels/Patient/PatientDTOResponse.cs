using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.DTOModels.Patient
{
    public class PatientDTOResponse : DefaultEntity, Interfaces.IModelSingleConvert<PatientDTOResponse, DataBase.Entities.Patient>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Patronymic { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Passport { get; set; }
        public string Address { get; set; }
        public string? WorkAddress { get; set; }
        public string? Telephone { get; set; }
        public byte[]? Photo { get; set; }
        public string? Email { get; set; }
        public int GenreId { get; set; }
        public DataBase.Entities.Patient ConvertToDAL(PatientDTOResponse model)
        {
            var DALModel = new DataBase.Entities.Patient()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth,
                Email = model.Email,
                GenreId = model.GenreId,
                LastName = model.LastName,
                Passport = model.Passport,
                WorkAddress = model.WorkAddress,
                Patronymic = model.Patronymic,
                Telephone = model.Telephone,
                Photo = model.Photo
            };
            return DALModel;
        }

        public PatientDTOResponse ConvertToDTO(DataBase.Entities.Patient model)
        {
            var DTOModel = new PatientDTOResponse()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth,
                Email = model.Email,
                GenreId = model.GenreId,
                LastName = model.LastName,
                Passport = model.Passport,
                WorkAddress = model.WorkAddress,
                Patronymic = model.Patronymic,
                Telephone = model.Telephone,
                Photo = model.Photo
            };
            return DTOModel;
        }
    }
}
