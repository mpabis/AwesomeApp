using System;
using System.Threading.Tasks;
using AwesomeApp.Core.ProjectAggregate;
using Xunit;

namespace AwesomeApp.IntegrationTests.Data
{
    public class EfRepositoryDelete : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task DeletesItemAfterAddingIt()
        {
            // add a shoppingList
            var repository = GetRepository();
            var initialName = Guid.NewGuid().ToString();
            var shoppingList = new ShoppingList(initialName);
            await repository.AddAsync(shoppingList);

            // delete the item
            await repository.DeleteAsync(shoppingList);

            // verify it's no longer there
            Assert.DoesNotContain(await repository.ListAsync(),
                list => list.Name == initialName);
        }
    }
}
