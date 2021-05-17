using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Result;
using AwesomeApp.Core.ProjectAggregate;
using AwesomeApp.Core.Interfaces;
using AwesomeApp.SharedKernel.Interfaces;
using AwesomeApp.Core.ProjectAggregate.Specifications;

namespace AwesomeApp.Core.Services
{
    public class ItemSearchService : IToDoItemSearchService
    {
        private readonly IRepository<ShoppingList> _repository;

        public ItemSearchService(IRepository<ShoppingList> repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<Item>>> GetAllIncompleteItemsAsync(int listId, string searchString)
        {
            if(string.IsNullOrEmpty(searchString))
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError()
                {
                    Identifier = nameof(searchString),
                    ErrorMessage = $"{nameof(searchString)} is required."
                });
                return Result<List<Item>>.Invalid(errors);
            }

            var shoppingListSpec = new ShoppingListByIdWithItemsSpec(listId);
            var shoppingList = await _repository.GetBySpecAsync(shoppingListSpec);

            if (shoppingList == null) return Result<List<Item>>.NotFound();

            var incompleteSpec = new IncompleteItemsSearchSpec(searchString);

            try
            {
                var items = incompleteSpec.Evaluate(shoppingList.Items).ToList();

                return new Result<List<Item>>(items);
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<List<Item>>.Error(new[] { ex.Message });
            }
        }

        public async Task<Result<Item>> GetNextIncompleteItemAsync(int projectId)
        {
            var shoppingListSpec = new ShoppingListByIdWithItemsSpec(projectId);
            var shoppingList = await _repository.GetBySpecAsync(shoppingListSpec);

            var incompleteSpec = new IncompleteItemsSpec();

            var items = incompleteSpec.Evaluate(shoppingList.Items).ToList();

            if (!items.Any())
            {
                return Result<Item>.NotFound();
            }

            return new Result<Item>(items.First());
        }
    }
}
