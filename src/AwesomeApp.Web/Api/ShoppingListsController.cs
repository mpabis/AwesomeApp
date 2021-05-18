using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeApp.Core.ProjectAggregate;
using AwesomeApp.Core.ProjectAggregate.Specifications;
using AwesomeApp.SharedKernel.Interfaces;
using AwesomeApp.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeApp.Web.Api
{
    /// <summary>
    /// A sample API Controller.
    /// </summary>
    public class ShoppingListsController : BaseApiController
    {
        private readonly IRepository<ShoppingList> _repository;

        public ShoppingListsController(IRepository<ShoppingList> repository)
        {
            _repository = repository;
        }

        // GET: api/ShoppingLists
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var projectDTOs = (await _repository.ListAsync())
                .Select(list => new ShoppingListDTO
                {
                    Id = list.Id,
                    Name = list.Name
                })
                .ToList();

            return Ok(projectDTOs);
        }

        // GET: api/ShoppingLists
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shoppingListSpec = new ShoppingListByIdWithItemsSpec(id);
            var shoppingList = await _repository.GetBySpecAsync(shoppingListSpec);

            var result = new ShoppingListDTO
            {
                Id = shoppingList.Id,
                Name = shoppingList.Name,
                Items = new List<ItemDTO>
                (
                    shoppingList.Items.Select(i => ItemDTO.FromToDoItem(i)).ToList()
                )
            };

            return Ok(result);
        }

        // POST: api/ShoppingLists
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateShoppingListDTO request)
        {
            var newProject = new ShoppingList(request.Name);

            var createdProject = await _repository.AddAsync(newProject);

            var result = new ShoppingListDTO
            {
                Id = createdProject.Id,
                Name = createdProject.Name
            };
            return Ok(result);
        }

        // PATCH: api/ShoppingLists/{projectId}/complete/{itemId}
        [HttpPatch("{projectId:int}/complete/{itemId}")]
        public async Task<IActionResult> Complete(int projectId, int itemId)
        {
            var shoppingListSpec = new ShoppingListByIdWithItemsSpec(projectId);
            var shoppingList = await _repository.GetBySpecAsync(shoppingListSpec);
            if (shoppingList == null) return NotFound("No such shoppingList");

            var toDoItem = shoppingList.Items.FirstOrDefault(item => item.Id == itemId);
            if (toDoItem == null) return NotFound("No such item.");

            toDoItem.MarkComplete();
            await _repository.UpdateAsync(shoppingList);

            return Ok();
        }
    }
}
