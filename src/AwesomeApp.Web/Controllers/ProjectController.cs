using System.Linq;
using System.Threading.Tasks;
using AwesomeApp.Core;
using AwesomeApp.Core.ProjectAggregate;
using AwesomeApp.Core.ProjectAggregate.Specifications;
using AwesomeApp.SharedKernel.Interfaces;
using AwesomeApp.Web.ApiModels;
using AwesomeApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeApp.Web.Controllers
{
    [Route("[controller]")]
    public class ShoppingListController : Controller
    {
        private readonly IRepository<ShoppingList> _projectRepository;

        public ShoppingListController(IRepository<ShoppingList> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        // GET shoppingList/{projectId?}
        [HttpGet("{projectId:int}")]
        public async Task<IActionResult> Index(int projectId = 1)
        {
            var spec = new ShoppingListByIdWithItemsSpec(projectId);
            var shoppingList = await _projectRepository.GetBySpecAsync(spec);

            var dto = new ShoppingListViewModel
            {
                Id = shoppingList.Id,
                Name = shoppingList.Name,
                Items = shoppingList.Items
                            .Select(item => ItemViewModel.FromItem(item))
                            .ToList()
            };
            return View(dto);
        }
    }
}
