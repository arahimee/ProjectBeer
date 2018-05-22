using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectBeer.API.Services
{
    public interface IBreweryDbHttpClient
    {
        Task<HttpResponseMessage> GetBeersAsync(string queryString);
        Task<HttpResponseMessage> GetBeerAsync(string id, string key);
    }
}
