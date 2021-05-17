using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AwesomeApp.Core.ProjectAggregate;
using AwesomeApp.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AwesomeApp.Web.Endpoints.ShoppingListEndpoints
{
    public class Create : BaseAsyncEndpoint
        .WithRequest<CreateShoppingListRequest>
        .WithResponse<CreateShoppingListResponse>
    {
        private readonly IRepository<ShoppingList> _repository;

        public Create(IRepository<ShoppingList> repository)
        {
            _repository = repository;
        }

        [HttpPost("/ShoppingLists")]
        [SwaggerOperation(
            Summary = "Creates a new ShoppingList",
            Description = "Creates a new ShoppingList",
            OperationId = "ShoppingList.Create",
            Tags = new[] { "ProjectEndpoints" })
        ]
        public override async Task<ActionResult<CreateShoppingListResponse>> HandleAsync(CreateShoppingListRequest request,
            CancellationToken cancellationToken)
        {
            var newProject = new ShoppingList(request.Name);

            var createdItem = await _repository.AddAsync(newProject); // TODO: pass cancellation token

            var response = new CreateShoppingListResponse
            {
                Id = createdItem.Id,
                Name = createdItem.Name
            };

            return Ok(response);
        }
    }
}
