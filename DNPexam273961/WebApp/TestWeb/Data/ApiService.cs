using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestWeb.Data
{
    public class ApiService
    {

        private readonly HttpClient client;
        public ApiService(IHttpClientFactory http)
        {
            client = http.CreateClient();
        }

        public async Task<double> Get()
        {
            var requestUri = $"calculate/cylinder?height={0}&radius={0}";
            var response = await client.GetAsync(requestUri);
            //return JsonSerializer.Deserialize<VolumeResult>(await response.Content.ReadAsStringAsync());
            return 0;
        }

        public async Task<List<double>> GetAll()
        {
            var requestUri = $"calculate/cylinder?height={0}&radius={0}";
            var response = await client.GetAsync(requestUri);
            //return JsonSerializer.Deserialize<VolumeResult>(await response.Content.ReadAsStringAsync());
            return new List<double>();
        }
        public async Task<double> Post(string type, decimal height, decimal radius)
        {
            var requestUri = $"calculate/cylinder?height={height}&radius={radius}";

            var response = await client.PostAsync($"calculate/{type}?height={height}&radius={radius}", new StringContent("", Encoding.UTF8, "application/json"));
            //return JsonSerializer.Deserialize<VolumeResult>(await response.Content.ReadAsStringAsync());
            return 0;
        }

    }
}
