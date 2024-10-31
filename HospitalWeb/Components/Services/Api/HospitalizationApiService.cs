using Domain.DTOModels.Hospitalization;
using Microsoft.IdentityModel.Tokens;

namespace HospitalWeb.Components.Services.Api
{
    public class HospitalizationApiService
    {
        HttpClient HttpClient { get; set; }

        public HospitalizationApiService(HttpClient httpClient)
        {
            HttpClient = ApiService.CreateHttpClient();
        }
        public async Task<List<HospitalizationDTOResponseTable>> GetTableDatasAsync(string? parametr)
        {
            var responses = await HttpClient.GetFromJsonAsync<List<HospitalizationDTOResponseTable>>($"api/Hospitalization/tables/get/{parametr}");
            return responses;
        }

        public async Task<HospitalizationDTOResponse> Get(int hospitalizationId)
        {
            var responses = await HttpClient.GetFromJsonAsync<HospitalizationDTOResponse>($"/api/Hospitalization/get/{hospitalizationId}");
            return responses;
        }

        public async Task<int> Add(HospitalizationDTORequest hospitalization)
        {
            var responses = await HttpClient.PostAsJsonAsync<HospitalizationDTORequest>($"/api/Hospitalization", hospitalization);
            int result = int.Parse(await responses.Content.ReadAsStringAsync());
            return result;
        }

        public async Task Update(int id, HospitalizationDTORequest hospitalization)
        {
            var responses = await HttpClient.PutAsJsonAsync<HospitalizationDTORequest>($"/api/Hospitalization/{id}/{hospitalization}", hospitalization);
        }
    }
}
