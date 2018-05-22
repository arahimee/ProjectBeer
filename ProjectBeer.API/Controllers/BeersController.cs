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
        public async Task<IHttpActionResult> Get(string queryString)
        {
            var response = await _breweryDbHttpClient.GetBeersAsync(queryString);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<PaginatedBeerResult>(responseContent);
                return Ok(result);
            }
            
            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: api/Beers/5
        public async Task<IHttpActionResult> Get(string id, string key)
        {
            var response = await _breweryDbHttpClient.GetBeerAsync(id, key);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(responseContent);
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Beer>(jsonObject["data"].ToString());
                return Ok(result);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
