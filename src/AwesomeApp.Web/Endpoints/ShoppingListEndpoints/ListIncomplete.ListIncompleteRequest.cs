using Microsoft.AspNetCore.Mvc;

namespace AwesomeApp.Web.Endpoints.ShoppingListEndpoints
{
    public class ListIncompleteRequest
    {
        [FromRoute]
        public int ProjectId { get; set; }
        [FromQuery]
        public string SearchString { get; set; }
    }
}
