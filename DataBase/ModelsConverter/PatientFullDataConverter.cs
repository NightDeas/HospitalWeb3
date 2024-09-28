using DataBase.Entities;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataBase.ModelsConverter
{
    public class PatientFullDataConverter : JsonConverter<PatientFullData>
    {
        public override PatientFullData? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                var root = doc.RootElement;
                var patient = JsonSerializer.Deserialize<Patient>(root.GetProperty("Patient").GetRawText(), options);
                var insurancePolicy = JsonSerializer.Deserialize<InsurancePolicy>(root.GetProperty("InsurancePolicy").GetRawText(), options);
                var medCard = JsonSerializer.Deserialize<MedCard>(root.GetProperty("MedCard").GetRawText(), options);

                return new PatientFullData(patient, insurancePolicy, medCard);
            }
        }

        public override void Write(Utf8JsonWriter writer, PatientFullData value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Patient");
            JsonSerializer.Serialize(writer, value.Patient, options);
            writer.WritePropertyName("InsurancePolicy");
            JsonSerializer.Serialize(writer, value.InsurancePolicy, options);
            writer.WritePropertyName("MedCard");
            JsonSerializer.Serialize(writer, value.MedCard, options);
            writer.WriteEndObject();
        }
    }
}
