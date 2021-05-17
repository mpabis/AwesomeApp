using System.Linq;
using System.Threading.Tasks;
using AwesomeApp.Core.ProjectAggregate;
using Xunit;

namespace AwesomeApp.IntegrationTests.Data
{
    public class EfRepositoryAdd : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task AddsProjectAndSetsId()
        {
            var testProjectName = "testProject";
            var repository = GetRepository();
            var shoppingList = new ShoppingList(testProjectName);

            await repository.AddAsync(shoppingList);

            var newProject = (await repository.ListAsync())
                            .FirstOrDefault();

            Assert.Equal(testProjectName, newProject.Name);
            Assert.True(newProject?.Id > 0);
        }
    }
}
