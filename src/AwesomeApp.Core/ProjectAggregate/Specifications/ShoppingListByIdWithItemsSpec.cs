using Ardalis.Specification;

namespace AwesomeApp.Core.ProjectAggregate.Specifications
{
    public class ShoppingListByIdWithItemsSpec : Specification<ShoppingList>, ISingleResultSpecification
    {
        public ShoppingListByIdWithItemsSpec(int projectId)
        {
            Query
                .Where(list => list.Id == projectId)
                .Include(list => list.Items);
        }
    }
}
