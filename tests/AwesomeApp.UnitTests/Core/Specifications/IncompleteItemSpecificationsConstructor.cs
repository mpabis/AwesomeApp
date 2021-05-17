using System.Collections.Generic;
using System.Linq;
using AwesomeApp.Core.ProjectAggregate;
using AwesomeApp.Core.ProjectAggregate.Specifications;
using Xunit;

namespace AwesomeApp.UnitTests.Core.Specifications
{
    public class IncompleteItemsSpecificationConstructor
    {
        [Fact]
        public void FilterCollectionToOnlyReturnItemsWithIsDoneFalse()
        {
            var item1 = new Item();
            var item2 = new Item();
            var item3 = new Item();
            item3.MarkComplete();

            var items = new List<Item>() { item1, item2, item3 };

            var spec = new IncompleteItemsSpec();
            List<Item> filteredList = items
                .Where(spec.WhereExpressions.First().Compile())
                .ToList();

            Assert.Contains(item1, filteredList);
            Assert.Contains(item2, filteredList);
            Assert.DoesNotContain(item3, filteredList);
        }
    }
}
