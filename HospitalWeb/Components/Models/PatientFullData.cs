using DataBase.Entities;
namespace HospitalWeb.Components.Models
{
    /// <summary>
    /// Вся доступная информация о пациенте
    /// </summary>
    public class PatientFullData
    {
        Patient Patient;
        InsurancePolicy InsurancePolicy;
        MedCard MedCard;

        public PatientFullData(Patient patient, InsurancePolicy insurancePolicy, MedCard medCard)
        {
            Patient = patient;
            InsurancePolicy = insurancePolicy;
            MedCard = medCard;
        }
    }
}
