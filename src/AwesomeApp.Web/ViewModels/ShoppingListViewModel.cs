using System.Collections.Generic;

namespace AwesomeApp.Web.ViewModels
{
    public class ShoppingListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ItemViewModel> Items = new();
    }
}
