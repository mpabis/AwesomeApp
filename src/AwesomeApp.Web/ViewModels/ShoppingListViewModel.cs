using System.Collections.Generic;
using System.Linq;
using AwesomeApp.Core.ProjectAggregate;

namespace AwesomeApp.Web.ViewModels
{
    public class ShoppingListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ItemViewModel> Items = new();

        public static ShoppingListViewModel FromShoppingList(ShoppingList shoppingList)
        {
            return new ShoppingListViewModel
            {
                Id = shoppingList.Id,
                Name = shoppingList.Name,
                Items = shoppingList.Items
                    .Select(i => ItemViewModel.FromItem(i))
                    .ToList()
            };
        }

    }
}
