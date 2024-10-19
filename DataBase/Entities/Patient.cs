using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Runtime;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace DataBase.Entities
{
    [PrimaryKey("Id")]
    public partial class Patient : DefaultEntity
    {
        [Required]
        public string LastName { get; set; }
		[Required]
		public string FirstName { get; set; }
        public string? Patronymic { get; set; }
		[Required]

		public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(11)]
        [MinLength(11)]
		public string Passport { get; set; }
		[Required]
		public string Address { get; set; }
        public string? WorkAddress { get; set; }
        [RegularExpression("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$")]
        public string? Telephone { get; set; }
        public byte[]? Photo { get; set; }
		[EmailAddressAttribute]
		public string? Email { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual InsurancePolicy InsurancePolicy{ get;set;} 
        public virtual MedCard MedCard{ get; set; }
    }
}