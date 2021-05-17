using System.ComponentModel.DataAnnotations;

namespace AwesomeApp.Web.Endpoints.ShoppingListEndpoints
{
    public class CreateShoppingListRequest
    {
        public const string Route = "/ShoppingLists";

        [Required]
        public string Name { get; set; }
    }
}