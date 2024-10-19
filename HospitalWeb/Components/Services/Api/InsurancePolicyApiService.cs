using Domain.DTOModels.Insurance;
using Domain.DTOModels.MedCard;
using Domain.DTOModels.Patient;

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

        public async Task<int> Add(InsurancePolicyDTORequest insurancePolicy)
        {
            var responses = await HttpClient.PostAsJsonAsync<InsurancePolicyDTORequest>($"/api/InsurancePolicy", insurancePolicy);
            int result = int.Parse(await responses.Content.ReadAsStringAsync());
            return result;
        }
    }
}
