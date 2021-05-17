using System.Collections.Generic;
using System.Linq;
using AwesomeApp.Core.ProjectAggregate;

namespace AwesomeApp.Web.ViewModels
{
    public class ShoppingListsViewModel
    {
        public List<ShoppingListViewModel> ShoppingLists = new();

        public static ShoppingListsViewModel FromShoppingLists(List<ShoppingList> shoppingList)
        {
            return new ShoppingListsViewModel
            {
                ShoppingLists = shoppingList
                    .Select(sl => ShoppingListViewModel.FromShoppingList(sl))
                    .ToList()
            };
        }

    }
}
