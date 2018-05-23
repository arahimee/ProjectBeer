using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjectBeer.API.Controllers;
using ProjectBeer.API.Models;
using ProjectBeer.API.Services;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace ProjectBeer.API.Tests
{
    [TestClass]
    public class BeersControllerTests
    {
        private BeersController _beersController;

        private Mock<IBreweryDbHttpClient> _breweryDbHttpClientMock;

        private string beersJson = @"{'currentPage':1,'numberOfPages':1,'totalResults':1,
            'data':[{'id':'StdoHr','name':'beer-test','nameDisplay':'beer-test','description':'Imperial Bitter','abv':'8.2',
            'styleId':13,'isOrganic':'N','status':'new_unverified','statusDisplay':'New, Unverified',
            'createDate':'2018-05-10 19:07:18','updateDate':'2018-05-10 19:07:21'}]}";

        private string beerJson = @"{'data':{'id':'StdoHr','name':'beer-test','nameDisplay':'beer-test','description':'Imperial Bitter','abv':'8.2',
            'styleId':13,'isOrganic':'N','status':'new_unverified','statusDisplay':'New, Unverified',
            'createDate':'2018-05-10 19:07:18','updateDate':'2018-05-10 19:07:21'}}";

        [TestInitialize]
        public void Initialize()
        {
            _breweryDbHttpClientMock = new Mock<IBreweryDbHttpClient>();
            _beersController = new BeersController(_breweryDbHttpClientMock.Object);
        }
        
        [TestMethod]
        public async Task GetBeers_Returns_HttpStatusInternalServerError_If_Not_Succeeded()
        {
            var httpResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);

            _breweryDbHttpClientMock.Setup(client => client.GetBeersAsync("key", 1, "", "Y", "-10", "verified", "name", "asc"))
                .Returns(Task.FromResult(httpResponse));

            var result = await _beersController.Get("key", 1, "", "Y", "-10", "verified", "name", "asc");

            Assert.AreEqual(HttpStatusCode.InternalServerError, ((StatusCodeResult)result).StatusCode);
        }

        [TestMethod]
        public async Task GetBeers_Returns_HttpStatusOK_If_Succeeded()
        {
            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK);

            httpResponse.Content = new StringContent(beersJson);

            _breweryDbHttpClientMock.Setup(client => client.GetBeersAsync("key", 1, "", "Y", "-10", "verified", "name", "asc"))
                .Returns(Task.FromResult(httpResponse));

            var result = await _beersController.Get("key", 1, "", "Y", "-10", "verified", "name", "asc");

            Assert.AreEqual(typeof(OkNegotiatedContentResult<PaginatedBeerResult>), result.GetType());
        }

        [TestMethod]
        public async Task GetBeers_Deserializes_BeersJSON_From_BreweryDb()
        {
            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK);

            httpResponse.Content = new StringContent(beersJson);

            _breweryDbHttpClientMock.Setup(client => client.GetBeersAsync("key", 1, "", "Y", "-10", "verified", "name", "asc"))
                .Returns(Task.FromResult(httpResponse));

            var result = await _beersController.Get("key", 1, "", "Y", "-10", "verified", "name", "asc");

            Assert.AreEqual(1, ((OkNegotiatedContentResult<PaginatedBeerResult>)result).Content.TotalResults);
            Assert.AreEqual("beer-test", ((OkNegotiatedContentResult<PaginatedBeerResult>)result).Content.Data.FirstOrDefault().NameDisplay);
        }

        [TestMethod]
        public async Task GetBeer_Returns_HttpStatusInternalServerError_If_Not_Succeeded()
        {
            var httpResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);

            _breweryDbHttpClientMock.Setup(client => client.GetBeerAsync("key", "id"))
                .Returns(Task.FromResult(httpResponse));

            var result = await _beersController.Get("key", "id");

            Assert.AreEqual(HttpStatusCode.InternalServerError, ((StatusCodeResult)result).StatusCode);
        }

        [TestMethod]
        public async Task GetBeer_Returns_HttpStatusOK_If_Succeeded()
        {
            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK);

            httpResponse.Content = new StringContent(beerJson);

            _breweryDbHttpClientMock.Setup(client => client.GetBeerAsync("key", "id"))
                .Returns(Task.FromResult(httpResponse));

            var result = await _beersController.Get("key", "id");

            Assert.AreEqual(typeof(OkNegotiatedContentResult<Beer>), result.GetType());
        }

        [TestMethod]
        public async Task GetBeer_Deserializes_BeerJSON_From_BreweryDb()
        {
            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK);

            httpResponse.Content = new StringContent(beerJson);

            _breweryDbHttpClientMock.Setup(client => client.GetBeerAsync("key", "id"))
                .Returns(Task.FromResult(httpResponse));

            var result = await _beersController.Get("key", "id");

            Assert.AreEqual("StdoHr", ((OkNegotiatedContentResult<Beer>)result).Content.Id);
            Assert.AreEqual("beer-test", ((OkNegotiatedContentResult<Beer>)result).Content.NameDisplay);
        }
    }
}
