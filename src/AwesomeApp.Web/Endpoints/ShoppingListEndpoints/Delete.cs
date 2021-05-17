using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AwesomeApp.Core.ProjectAggregate;
using AwesomeApp.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AwesomeApp.Web.Endpoints.ShoppingListEndpoints
{
    public class Delete : BaseAsyncEndpoint
        .WithRequest<DeleteShoppingListRequest>
        .WithoutResponse
    {
        private readonly IRepository<ShoppingList> _repository;

        public Delete(IRepository<ShoppingList> repository)
        {
            _repository = repository;
        }

        [HttpDelete(DeleteShoppingListRequest.Route)]
        [SwaggerOperation(
            Summary = "Deletes a ShoppingList",
            Description = "Deletes a ShoppingList",
            OperationId = "ShoppingLists.Delete",
            Tags = new[] { "ProjectEndpoints" })
        ]
        public override async Task<ActionResult> HandleAsync([FromRoute]DeleteShoppingListRequest request,
            CancellationToken cancellationToken)
        {
            var aggregateToDelete = await _repository.GetByIdAsync(request.ProjectId); // TODO: pass cancellation token
            if (aggregateToDelete == null) return NotFound();

            await _repository.DeleteAsync(aggregateToDelete);

            return NoContent();
        }
    }
}
