using System.Collections.Generic;

namespace AwesomeApp.Web.Endpoints.ShoppingListEndpoints
{
    public class ListIncompleteResponse
    {
        public int ProjectId { get; set; }
        public List<ItemRecord> IncompleteItems { get; set; }
    }
}
