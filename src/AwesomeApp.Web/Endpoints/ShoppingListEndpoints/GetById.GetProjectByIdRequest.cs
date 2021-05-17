namespace AwesomeApp.Web.Endpoints.ShoppingListEndpoints
{
    public class GetShoppingListByIdRequest
    {
        public const string Route = "/ShoppingLists/{ProjectId:int}";
        public static string BuildRoute(int projectId) => Route.Replace("{ProjectId:int}", projectId.ToString());

        public int ProjectId { get; set; }
    }
}
