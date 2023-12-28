using StockServiceHttpClient.Models;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace StockServiceHttpClient.StockService
{
    public class Stock : IStock { 

    
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _configuration;
        public Stock(IHttpClientFactory httpClient,IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<StockModel> GetStockReport(string StockName)
        {
            var url = $"https://finnhub.io/api/v1/quote?symbol={StockName}&token={_configuration["FinHubToken"]}";

            using(var client = _httpClient.CreateClient())
            {
                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, url);
                var resp = await client.SendAsync(req);
                var stream = resp.Content.ReadAsStream();
                var reader = new StreamReader(stream).ReadToEnd();
                var stockdata = JsonSerializer.Deserialize<StockModel>(reader);
                return stockdata;

            }
        }

        public async Task<List<StockSymbol>> GetStockSymbol()
        {
            var url = $"https://finnhub.io/api/v1/stock/symbol?exchange=US&token={_configuration["FinHubToken"]}";

            using (var client = _httpClient.CreateClient())
            {
                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, url);
                var resp = await client.SendAsync(req);
                var stream = resp.Content.ReadAsStream();
                var reader = new StreamReader(stream).ReadToEnd();
                var stockdata = JsonSerializer.Deserialize<List<StockSymbol>>(reader);
                return stockdata;

            }
        }
    }
}
