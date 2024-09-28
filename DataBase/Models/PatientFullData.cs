using DataBase.Entities;
using System.Text.Json.Serialization;
namespace DataBase.Models
{
    /// <summary>
    /// Вся доступная информация о пациенте
    /// </summary>
    public class PatientFullData
    {
        public Patient Patient { get; set; }
        public InsurancePolicy InsurancePolicy { get; set; }
        public MedCard MedCard { get; set; }

        [JsonConstructor]
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
