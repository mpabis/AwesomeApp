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
        public static readonly ShoppingList TestShoppingList = new ShoppingList("Test ShoppingList");
        public static readonly Item Item1 = new Item
        {
            Title = "Bread",
            Description = ""
        };
        public static readonly Item Item2 = new Item
        {
            Title = "Eggs",
            Description = "Free range eggs"
        };
        public static readonly Item Item3 = new Item
        {
            Title = "Milk",
            Description = ""
        };

        public static void Initialize(IServiceProvider serviceProvider)
        {
            InitializeAppContext(serviceProvider);
            InitializeAuditContext(serviceProvider);
        }

        private static void InitializeAuditContext(IServiceProvider serviceProvider)
        {
            using var dbContext = new AuditDbContext(serviceProvider.GetRequiredService<DbContextOptions<AuditDbContext>>());
            if (dbContext.AuditEntries.Any())
            {
                return;
            }

            PopulateAuditEntries(dbContext);
        }

        private static void PopulateAuditEntries(AuditDbContext dbContext)
        {
            foreach (var item in dbContext.AuditEntries)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();
            
            dbContext.AuditEntries.Add(new AuditEntry { DateTime = DateTime.Now, Entry = "Initialization" });

            dbContext.SaveChanges();
        }

        private static void InitializeAppContext(IServiceProvider serviceProvider)
        {
            using var dbContext = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null);
            // if (dbContext.Items.Any())
            // {
            //     return;
            // }

            PopulateTestData(dbContext);
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
