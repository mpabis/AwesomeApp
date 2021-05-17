using System.ComponentModel.DataAnnotations;

namespace AwesomeApp.Web.Endpoints.ShoppingListEndpoints
{
    public class UpdateProjectRequest
    {
        public const string Route = "/ShoppingLists";
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}