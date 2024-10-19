using DataBase.Entities;
using DataBase.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOModels.Patient
{
    public class PatientDTORequest : Interfaces.IModelSingleConvert<PatientDTORequest, DataBase.Entities.Patient>
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Passport { get; set; }
        public string Address { get; set; }
        public string? WorkAddress { get; set; }
        public string? Telephone { get; set; }
        public byte[]? Photo { get; set; } = null;
        public string? Email { get; set; }
        public DataBase.Enums.Genres GenreId { get; set; }
        public string InsuranceNumber { get; set; }
        public DateTime InsuranceEnd { get; set; }

        public DataBase.Entities.Patient ConvertToDAL(PatientDTORequest model)
        {
            var DALModel = new DataBase.Entities.Patient()
            {
                Id = model.Id,
                DateOfBirth = model.DateOfBirth,
                Passport = model.Passport,
                Address = model.Address,
                Telephone = model.Telephone,
                Photo = model.Photo,
                Email = model.Email,
                FirstName = model.FirstName,
                GenreId = (int)model.GenreId,
                LastName = model.LastName,
                Patronymic = model.Patronymic,
                WorkAddress = model.WorkAddress,
            };
            return DALModel;    
        }

        public PatientDTORequest ConvertToDTO(DataBase.Entities.Patient model)
        {
            var DTOModel = new PatientDTORequest()
            {
                Id = model.Id,
                DateOfBirth = model.DateOfBirth,
                Passport = model.Passport,
                Address = model.Address,
                Telephone = model.Telephone,
                Photo = model.Photo,
                Email = model.Email,
                FirstName = model.FirstName,
                GenreId = (Genres)model.GenreId,
                LastName = model.LastName,
                Patronymic = model.Patronymic,
                WorkAddress = model.WorkAddress,
            };
            return DTOModel;
        }
    }
}
