using Newtonsoft.Json.Linq;
using ProjectBeer.API.Models;
using ProjectBeer.API.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProjectBeer.API.Controllers
{
    public class BeersController : ApiController
    {
        private readonly IBreweryDbHttpClient _breweryDbHttpClient;

        public BeersController()
        {
            // todo: use Unity (dependency injection)
            _breweryDbHttpClient = new BreweryDbHttpClient();
        }

        public BeersController(IBreweryDbHttpClient breweryDbHttpClient)
        {
            _breweryDbHttpClient = breweryDbHttpClient;
        }

        // GET: api/Beers
        public async Task<IHttpActionResult> Get(string breweryDbApiKey, int pageNumber, string name, string isOrganic, string abv, string status, string order, string sort)
        {
            var response = await _breweryDbHttpClient.GetBeersAsync(breweryDbApiKey, pageNumber, name, isOrganic, abv, status, order, sort);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<PaginatedBeerResult>(responseContent);
                return Ok(result);
            }
            
            return StatusCode(HttpStatusCode.InternalServerError);
        }

        // GET: api/Beers/5
        public async Task<IHttpActionResult> Get(string id, string breweryDbApiKey)
        {
            var response = await _breweryDbHttpClient.GetBeerAsync(id, breweryDbApiKey);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(responseContent);
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Beer>(jsonObject["data"].ToString());
                return Ok(result);
            }

            return StatusCode(HttpStatusCode.InternalServerError);
        }
    }
}
