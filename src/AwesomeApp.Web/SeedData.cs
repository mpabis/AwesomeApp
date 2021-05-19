using System;
using System.Linq;
using AwesomeApp.Core.ProjectAggregate;
using AwesomeApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeApp.Web
{
    public static class SeedData
    {
        public static readonly ShoppingList TestShoppingList = new ShoppingList("Shopping List");
        public static readonly Item Item1 = new Item
        {
            Title = "Break",
            Description = ""
        };
        public static readonly Item Item2 = new Item
        {
            Title = "Eggs",
            Description = "Freerange eggs"
        };
        public static readonly Item Item3 = new Item
        {
            Title = "Milk",
            Description = ""
        };

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
            {
                // Look for any TODO items.
                if (dbContext.Items.Any())
                {
                    return;   // DB has been seeded
                }

                PopulateTestData(dbContext);


            }
        }
        public static void PopulateTestData(AppDbContext dbContext)
        {
            foreach (var item in dbContext.Items)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();

            TestShoppingList.AddItem(Item1);
            TestShoppingList.AddItem(Item2);
            TestShoppingList.AddItem(Item3);
            dbContext.ShoppingLists.Add(TestShoppingList);

            dbContext.SaveChanges();
        }
    }
}
