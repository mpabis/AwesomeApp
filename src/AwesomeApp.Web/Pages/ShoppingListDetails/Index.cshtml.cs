using System.Linq;
using System.Threading.Tasks;
using AwesomeApp.Core.ProjectAggregate;
using AwesomeApp.Core.ProjectAggregate.Specifications;
using AwesomeApp.SharedKernel.Interfaces;
using AwesomeApp.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AwesomeApp.Web.Pages.ShoppingListDetails
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<ShoppingList> _repository;

        [BindProperty(SupportsGet = true)]
        public int ProjectId { get; set; }
        public string Message { get; set; } = "";

        public ShoppingListDTO ShoppingList { get; set; }

        public IndexModel(IRepository<ShoppingList> repository)
        {
            _repository = repository;
        }

        public async Task OnGetAsync()
        {
            var spec = new ShoppingListByIdWithItemsSpec(ProjectId);
            var shoppingList = await _repository.GetBySpecAsync(spec);

            if(shoppingList == null)
            {
                Message = "No shoppingList found.";
                return;
            }

            ShoppingList = new ShoppingListDTO
            {
                Id = shoppingList.Id,
                Name = shoppingList.Name,
                Items = shoppingList.Items
                .Select(item => ItemDTO.FromToDoItem(item))
                .ToList()
            };
        }
    }
}
