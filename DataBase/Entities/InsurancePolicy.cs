using System.ComponentModel.DataAnnotations;

namespace DataBase.Entities
{
	public class InsurancePolicy : DefaultEntity
	{
		public InsurancePolicy()
		{
			End = DateTime.Now.AddYears(10);
		}

		[MaxLength(16)]
		[MinLength(16)]
		public string Number { get; set; }
		public DateTime End { get; set; }

		public int PatientId { get; set; }

		public virtual Patient Patient { get; set; }


	}
}