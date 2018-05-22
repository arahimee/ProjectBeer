using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProjectBeer.API.Services
{
    public class BreweryDbHttpClient : IBreweryDbHttpClient
    {
        private readonly HttpClient _httpClient;

        public BreweryDbHttpClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://api.brewerydb.com");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HttpResponseMessage> GetBeersAsync(string queryString)
        {
            var response = await _httpClient.GetAsync($"v2/beers?{queryString}");

            return response;
        }

        public async Task<HttpResponseMessage> GetBeerAsync(string id, string key)
        {
            var response = await _httpClient.GetAsync($"v2/beer/{id}?key={key}");

            return response;
        }
    }
}