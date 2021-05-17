using Ardalis.Specification;

namespace AwesomeApp.Core.ProjectAggregate.Specifications
{
    public class IncompleteItemsSpec : Specification<Item>
    {
        public IncompleteItemsSpec()
        {
            Query.Where(item => !item.IsDone);
        }
    }
}
