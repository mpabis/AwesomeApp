using AwesomeApp.Core.ProjectAggregate;
using System;
using Xunit;

namespace AwesomeApp.UnitTests.Core.ProjectAggregate
{
    public class Project_AddItem
    {
        private ShoppingList _testShoppingList = new ShoppingList("some name");

        [Fact]
        public void AddsItemToItems()
        {
            var _testItem = new Item
            {
                Title = "title",
                Description = "description"
            };

            _testShoppingList.AddItem(_testItem);

            Assert.Contains(_testItem, _testShoppingList.Items);
        }

        [Fact]
        public void ThrowsExceptionGivenNullItem()
        {
            Action action = () => _testShoppingList.AddItem(null);

            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("newItem", ex.ParamName);
        }
    }
}
