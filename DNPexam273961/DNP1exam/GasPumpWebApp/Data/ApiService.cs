using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GasPump;

namespace GasPumpWebApp.Data
{
    public class ApiService
    {

        private readonly HttpClient client;
        public ApiService(IHttpClientFactory http)
        {
            client = http.CreateClient();
        }

        public async Task<double> GetTankCost(decimal size)
        {
            try
            {
                var requestUri = $"/gaspump/CostOfFullTank?size={size}";
                var response = await client.GetAsync(requestUri);
                return JsonSerializer.Deserialize<double>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
        public async Task<double> GetFillTank(decimal amount)
        {
            try
            {
                var requestUri = $"/gaspump/FillTank?amount={amount}";
                var response = await client.GetAsync(requestUri);
                if (response.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<double>(await response.Content.ReadAsStringAsync());
                }

                throw new Exception(await response.Content.ReadAsStringAsync());

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public async Task<DateTime> PostFillPump()
        {
            try
            {
                var requestUri = $"/gaspump/FillPump";
                var response = await client.PostAsync(requestUri, new StringContent("", Encoding.UTF8, "application/json"));
                return JsonSerializer.Deserialize<DateTime>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }



        // History

        public async Task<List<PumpUsageHistory>> GetAllTankHistory()
        {
            try
            {
                var requestUri = $"/gaspump/FillTank/history";
                var response = await client.GetAsync(requestUri);
                return JsonSerializer.Deserialize<List<PumpUsageHistory>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           

        }

        public async Task<List<PumpFillHistory>> GetAllPumpHistory()
        {
            try
            {
                var requestUri = $"/gaspump/FillPump/history";
                var response = await client.GetAsync(requestUri);
                return JsonSerializer.Deserialize<List<PumpFillHistory>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           

        }

    }
}