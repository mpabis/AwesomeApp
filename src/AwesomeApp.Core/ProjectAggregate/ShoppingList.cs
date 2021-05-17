using Ardalis.GuardClauses;
using AwesomeApp.Core.ProjectAggregate.Events;
using AwesomeApp.SharedKernel;
using AwesomeApp.SharedKernel.Interfaces;
using System.Collections.Generic;

namespace AwesomeApp.Core.ProjectAggregate
{
    public class ShoppingList : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }

        private List<Item> _items = new List<Item>();
        public IEnumerable<Item> Items => _items.AsReadOnly();

        public ShoppingList(string name)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
        }

        public void AddItem(Item newItem)
        {
            Guard.Against.Null(newItem, nameof(newItem));
            _items.Add(newItem);

            var newItemAddedEvent = new NewItemAddedEvent(this, newItem);
            Events.Add(newItemAddedEvent);
        }

        public void UpdateName(string newName)
        {
            Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
        }
    }
}
