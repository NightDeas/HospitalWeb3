using Domain.DTOModels.MedCard;
using Domain.DTOModels.Patient;

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

        public async Task<int> Add(MedCardDTORequestPost medCard)
        {
            var responses = await HttpClient.PostAsJsonAsync<MedCardDTORequestPost>($"/api/MedCard", medCard);
            int result = int.Parse(await responses.Content.ReadAsStringAsync());
            return result;
        }
    }
}
