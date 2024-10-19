using Domain.DTOModels.MedCard;

namespace HospitalWeb.Components.Services.Api
{
    public class MedCardApiService
    {
        public HttpClient HttpClient { get; set; }

        public MedCardApiService(HttpClient httpClient)
        {
            HttpClient = ApiService.CreateHttpClient();
        }

        public async Task<MedCardDTOResponse> GetByPatient(int patientId)
        {
            var result = await HttpClient.GetFromJsonAsync<MedCardDTOResponse>($"/api/MedCard/patient/{patientId}");
            return result;
        }
    }
}
