using AwesomeApp.Core.ProjectAggregate;

namespace AwesomeApp.Web.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; private set; }

        public static ItemViewModel FromItem(Item item)
        {
            return new ItemViewModel()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsDone = item.IsDone
            };
        }
    }
}
