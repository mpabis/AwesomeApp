using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Result;
using AwesomeApp.Core.ProjectAggregate;

namespace AwesomeApp.Core.Interfaces
{
    public interface IToDoItemSearchService
    {
        Task<Result<Item>> GetNextIncompleteItemAsync(int projectId);
        Task<Result<List<Item>>> GetAllIncompleteItemsAsync(int listId, string searchString);
    }
}
