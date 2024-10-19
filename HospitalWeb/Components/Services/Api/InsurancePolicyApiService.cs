using Domain.DTOModels.Insurance;
using Domain.DTOModels.MedCard;

namespace HospitalWeb.Components.Services.Api
{
    public class InsurancePolicyApiService
    {
        public HttpClient HttpClient { get; set; }

        public InsurancePolicyApiService(HttpClient httpClient)
        {
            HttpClient = ApiService.CreateHttpClient();
        }

        public async Task<InsurancePolicyDTOResponse> GetByPatient(int patientId)
        {
            var result = await HttpClient.GetFromJsonAsync<InsurancePolicyDTOResponse>($"/api/InsurancePolicy/patient/{patientId}");
            return result;
        }
    }
}
