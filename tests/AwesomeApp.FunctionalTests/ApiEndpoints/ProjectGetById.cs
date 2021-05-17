using System.Net.Http;
using System.Threading.Tasks;
using Ardalis.HttpClientTestExtensions;
using AwesomeApp.Web;
using AwesomeApp.Web.Endpoints.ShoppingListEndpoints;
using Xunit;

namespace AwesomeApp.FunctionalTests.ApiEndpoints
{
    [Collection("Sequential")]
    public class ProjectGetById : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ProjectGetById(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsSeedProjectGivenId1()
        {
            var result = await _client.GetAndDeserialize<GetShoppingListByIdResponse>(GetShoppingListByIdRequest.BuildRoute(1));

            Assert.Equal(1, result.Id);
            Assert.Equal(SeedData.TestShoppingList.Name, result.Name);
            Assert.Equal(3, result.Items.Count);
        }

        [Fact]
        public async Task ReturnsNotFoundGivenId0()
        {
            string route = GetShoppingListByIdRequest.BuildRoute(0);
            _ = await _client.GetAndEnsureNotFound(route);
        }
    }
}
