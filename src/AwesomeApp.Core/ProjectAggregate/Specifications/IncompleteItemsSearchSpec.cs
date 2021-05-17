using Ardalis.Specification;

namespace AwesomeApp.Core.ProjectAggregate.Specifications
{
    public class IncompleteItemsSearchSpec : Specification<Item>
    {
        public IncompleteItemsSearchSpec(string searchString)
        {
            Query
                .Where(item => !item.IsDone &&
                (item.Title.Contains(searchString) ||
                item.Description.Contains(searchString)));
        }
    }
}
