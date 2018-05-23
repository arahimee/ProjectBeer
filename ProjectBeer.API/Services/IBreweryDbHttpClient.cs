using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectBeer.API.Services
{
    public interface IBreweryDbHttpClient
    {
        Task<HttpResponseMessage> GetBeersAsync(string breweryDbApiKey, int pageNumber, string name, string isOrganic, string abv, string status, string order, string sort);
        Task<HttpResponseMessage> GetBeerAsync(string id, string breweryDbApiKey);
    }
}
