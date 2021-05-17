using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AwesomeApp.Core.ProjectAggregate;
using AwesomeApp.Core.ProjectAggregate.Specifications;
using AwesomeApp.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AwesomeApp.Web.Endpoints.ShoppingListEndpoints
{
    public class GetById : BaseAsyncEndpoint
        .WithRequest<GetShoppingListByIdRequest>
        .WithResponse<GetShoppingListByIdResponse>
    {
        private readonly IRepository<ShoppingList> _repository;

        public GetById(IRepository<ShoppingList> repository)
        {
            _repository = repository;
        }

        [HttpGet(GetShoppingListByIdRequest.Route)]
        [SwaggerOperation(
            Summary = "Gets a single ShoppingList",
            Description = "Gets a single ShoppingList by Id",
            OperationId = "ShoppingLists.GetById",
            Tags = new[] { "ProjectEndpoints" })
        ]
        public override async Task<ActionResult<GetShoppingListByIdResponse>> HandleAsync([FromRoute] GetShoppingListByIdRequest request,
            CancellationToken cancellationToken)
        {
            var spec = new ShoppingListByIdWithItemsSpec(request.ProjectId);
            var entity = await _repository.GetBySpecAsync(spec); // TODO: pass cancellation token
            if (entity == null) return NotFound();

            var response = new GetShoppingListByIdResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Items = entity.Items.Select(item => new ItemRecord(item.Id, item.Title, item.Description, item.IsDone)).ToList()
            };
            return Ok(response);
        }
    }
}
