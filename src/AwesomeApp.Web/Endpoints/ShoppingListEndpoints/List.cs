using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AwesomeApp.Core.ProjectAggregate;
using AwesomeApp.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AwesomeApp.Web.Endpoints.ShoppingListEndpoints
{
    public class List : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<ShoppingListsResponse>
    {
        private readonly IReadRepository<ShoppingList> _repository;

        public List(IReadRepository<ShoppingList> repository)
        {
            _repository = repository;
        }

        [HttpGet("/ShoppingLists")]
        [SwaggerOperation(
            Summary = "Gets a list of all ShoppingLists",
            Description = "Gets a list of all ShoppingLists",
            OperationId = "ShoppingList.List",
            Tags = new[] { "ProjectEndpoints" })
        ]
        public override async Task<ActionResult<ShoppingListsResponse>> HandleAsync(CancellationToken cancellationToken)
        {
            var response = new ShoppingListsResponse();
            response.Projects = (await _repository.ListAsync()) // TODO: pass cancellation token
                .Select(shoppingList => new ShoppingListRecord(shoppingList.Id, shoppingList.Name))
                .ToList();

            return Ok(response);
        }
    }
}
