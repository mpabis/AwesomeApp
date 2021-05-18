using AwesomeApp.Core.ProjectAggregate;

namespace AwesomeApp.UnitTests
{
    public class ToDoItemBuilder
    {
        private Item _todo = new Item();

        public ToDoItemBuilder Id(int id)
        {
            _todo.Id = id;
            return this;
        }

        public ToDoItemBuilder Title(string title)
        {
            _todo.Title = title;
            return this;
        }

        public ToDoItemBuilder Description(string description)
        {
            _todo.Description = description;
            return this;
        }

        public ToDoItemBuilder WithDefaultValues()
        {
            _todo = new Item() { Id = 1, Title = "Test Item", Description = "Test Description" };

            return this;
        }

        public Item Build() => _todo;
    }
}
