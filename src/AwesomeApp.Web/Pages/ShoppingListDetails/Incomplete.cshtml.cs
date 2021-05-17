using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeApp.Core.ProjectAggregate;
using AwesomeApp.Core.ProjectAggregate.Specifications;
using AwesomeApp.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AwesomeApp.Web.Pages.ShoppingListDetails
{
    public class IncompleteModel : PageModel
    {
        private readonly IRepository<ShoppingList> _repository;

        public List<Item> Items { get; set; }

        public IncompleteModel(IRepository<ShoppingList> repository)
        {
            _repository = repository;
        }

        public async Task OnGetAsync()
        {
            var spec = new ShoppingListByIdWithItemsSpec(1); // TODO: get from route
            var list = await _repository.GetBySpecAsync(spec);
            var incompleteItemsSpec = new IncompleteItemsSpec();

            Items = incompleteItemsSpec.Evaluate(list.Items).ToList();
        }
    }
}
