using System.Collections.Generic;

namespace AwesomeApp.Web.Endpoints.ShoppingListEndpoints
{
    public class GetShoppingListByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ItemRecord> Items { get; set; } = new();
    }
}