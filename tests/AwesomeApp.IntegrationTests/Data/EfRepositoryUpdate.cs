using System;
using System.Linq;
using System.Threading.Tasks;
using AwesomeApp.Core.ProjectAggregate;
using AwesomeApp.UnitTests;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AwesomeApp.IntegrationTests.Data
{
    public class EfRepositoryUpdate : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task UpdatesItemAfterAddingIt()
        {
            // add a shoppingList
            var repository = GetRepository();
            var initialName = Guid.NewGuid().ToString();
            var shoppingList = new ShoppingList(initialName);

            await repository.AddAsync(shoppingList);

            // detach the item so we get a different instance
            _dbContext.Entry(shoppingList).State = EntityState.Detached;

            // fetch the item and update its title
            var newProject = (await repository.ListAsync())
                .FirstOrDefault(list => list.Name == initialName);
            Assert.NotNull(newProject);
            Assert.NotSame(shoppingList, newProject);
            var newName = Guid.NewGuid().ToString();
            newProject.UpdateName(newName);

            // Update the item
            await repository.UpdateAsync(newProject);

            // Fetch the updated item
            var updatedItem = (await repository.ListAsync())
                .FirstOrDefault(list => list.Name == newName);

            Assert.NotNull(updatedItem);
            Assert.NotEqual(shoppingList.Name, updatedItem.Name);
            Assert.Equal(newProject.Id, updatedItem.Id);
        }
    }
}
