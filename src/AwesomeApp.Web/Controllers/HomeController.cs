using System.Threading.Tasks;
using AwesomeApp.Core.ProjectAggregate;
using AwesomeApp.SharedKernel.Interfaces;
using AwesomeApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeApp.Web.Controllers
{
    /// <summary>
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IRepository<ShoppingList> _shoppingListRepository;

        public HomeController(IRepository<ShoppingList> shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }

        public async Task<IActionResult> Index()
        {
            var shoppingList = await _shoppingListRepository.ListAsync();

            var dto = ShoppingListsViewModel.FromShoppingLists(shoppingList);

            return View(dto);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
