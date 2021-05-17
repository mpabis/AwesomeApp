using AwesomeApp.SharedKernel;

namespace AwesomeApp.Core.ProjectAggregate.Events
{
    public class NewItemAddedEvent : BaseDomainEvent
    {
        public Item NewItem { get; set; }
        public ShoppingList ShoppingList { get; set; }

        public NewItemAddedEvent(ShoppingList shoppingList,
            Item newItem)
        {
            ShoppingList = shoppingList;
            NewItem = newItem;
        }
    }
}