using DataBase.Entities;
namespace DataBase.Models
{
    /// <summary>
    /// Вся доступная информация о пациенте
    /// </summary>
    public class PatientFullData
    {
        public Patient Patient;
        public InsurancePolicy InsurancePolicy;
        public MedCard MedCard;

        public PatientFullData(Patient patient, InsurancePolicy insurancePolicy, MedCard medCard)
        {
            Patient = patient;
            InsurancePolicy = insurancePolicy;
            MedCard = medCard;
        }
    }
}
