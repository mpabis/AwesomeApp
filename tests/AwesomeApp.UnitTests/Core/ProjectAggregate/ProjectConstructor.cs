using AwesomeApp.Core.ProjectAggregate;
using Xunit;

namespace AwesomeApp.UnitTests.Core.ProjectAggregate
{
    public class ProjectConstructor
    {
        private string _testName = "test name";
        private ShoppingList _testShoppingList = null;

        private ShoppingList CreateProject()
        {
            return new ShoppingList(_testName);
        }

        [Fact]
        public void InitializesName()
        {
            _testShoppingList = CreateProject();

            Assert.Equal(_testName, _testShoppingList.Name);
        }

        [Fact]
        public void InitializesTaskListToEmptyList()
        {
            _testShoppingList = CreateProject();

            Assert.NotNull(_testShoppingList.Items);
        }
    }
}
