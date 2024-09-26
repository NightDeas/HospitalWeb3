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

        public PatientFullData(Patient patient)
        {
            Patient = patient;
            InsurancePolicy = patient.InsurancePolicy;
            MedCard = patient.MedCard;
        }

        public static List<PatientFullData> ToFullData(List<Patient> patients)
        {
            List<PatientFullData> patientFullDatas = new();
            foreach (var patient in patients)
            {
                patientFullDatas.Add(new PatientFullData(patient));
            }
            return patientFullDatas;
        }
    }
}
