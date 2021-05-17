using System.Collections.Generic;

namespace AwesomeApp.Web.Endpoints.ShoppingListEndpoints
{
    public class ShoppingListsResponse
    {
        public List<ShoppingListRecord> Projects { get; set; } = new();
    }
}
