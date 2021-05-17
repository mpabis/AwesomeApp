using AwesomeApp.Core.ProjectAggregate;
using AwesomeApp.SharedKernel;

namespace AwesomeApp.Core.ProjectAggregate.Events
{
    public class ItemBoughtEvent : BaseDomainEvent
    {
        public Item CompletedItem { get; set; }

        public ItemBoughtEvent(Item completedItem)
        {
            CompletedItem = completedItem;
        }
    }
}