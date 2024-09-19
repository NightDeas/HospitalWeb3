using Microsoft.Identity.Client;

namespace DataBase.Entities
{
    public class MedCard : DefaultEntity
    {
		public MedCard()
		{
            Created = DateTime.Now;
		}

		public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }


    }
}