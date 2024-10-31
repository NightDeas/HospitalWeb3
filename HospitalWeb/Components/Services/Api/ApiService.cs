using System.Xml.Serialization;

namespace HospitalWeb.Components.Services.Api
{
    public static class ApiService
    {
        public static HttpClient CreateHttpClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7236");
            client.Timeout = new TimeSpan(0, 0, 15);
            return client;
        }
    }
}
