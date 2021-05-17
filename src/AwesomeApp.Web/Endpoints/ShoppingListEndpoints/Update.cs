using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AwesomeApp.Core.ProjectAggregate;
using AwesomeApp.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AwesomeApp.Web.Endpoints.ShoppingListEndpoints
{
    public class Update : BaseAsyncEndpoint
        .WithRequest<UpdateProjectRequest>
        .WithResponse<UpdateProjectResponse>
    {
        private readonly IRepository<ShoppingList> _repository;

        public Update(IRepository<ShoppingList> repository)
        {
            _repository = repository;
        }

        [HttpPut(UpdateProjectRequest.Route)]
        [SwaggerOperation(
            Summary = "Updates a ShoppingList",
            Description = "Updates a ShoppingList with a longer description",
            OperationId = "ShoppingLists.Update",
            Tags = new[] { "ProjectEndpoints" })
        ]
        public override async Task<ActionResult<UpdateProjectResponse>> HandleAsync(UpdateProjectRequest request,
            CancellationToken cancellationToken)
        {
            var existingProject = await _repository.GetByIdAsync(request.Id); // TODO: pass cancellation token

            existingProject.UpdateName(request.Name);

            await _repository.UpdateAsync(existingProject); // TODO: pass cancellation token

            var response = new UpdateProjectResponse()
            {
                ShoppingList = new ShoppingListRecord(existingProject.Id, existingProject.Name)
            };
            return Ok(response);
        }
    }
}
