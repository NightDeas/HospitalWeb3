using Domain.DTOModels.Patient;
using System.Reflection.Metadata;

namespace HospitalWeb.Components.Services.Api
{
    public class PatientApiService
    {
        HttpClient HttpClient { get; set; }

        public PatientApiService(HttpClient httpClient)
        {
            HttpClient = ApiService.CreateHttpClient();
        }

        public async Task<List<PatientDTOResponseTableData>> GetTableDatasAsync()
        {
            var responses = await HttpClient.GetFromJsonAsync<List<Domain.DTOModels.Patient.PatientDTOResponseTableData>>("/api/Patient/tables/getAll");
            return responses;
        }
        public async Task<List<PatientDTOResponseTableData>> GetTableDatasAsync(string parametr)
        {
            var responses = await HttpClient.GetFromJsonAsync<List<Domain.DTOModels.Patient.PatientDTOResponseTableData>>($"/api/Patient/tables/get/{parametr}");
            return responses;
        }

        public async Task<PatientDTOResponse> Get(int patientId)
        {
            var responses = await HttpClient.GetFromJsonAsync<PatientDTOResponse>($"/api/Patient/get/{patientId}");
            return responses;
        }
    }
}
