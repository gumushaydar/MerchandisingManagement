using Merchandising.Domain.Entities;
using Merchandising.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchandising.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "admin!");
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category
                {
                    Name = "Computer",
                    MinimumStockQuantity = 5,
                    Products =
                    {
                        new Product { Title = "Macbook Pro", Description = "Üstün Performans", StockQuantity = 3  },
                        new Product { Title = "Asus", Description = "Gücü Hisset", StockQuantity = 7  },
                        new Product { Title = "Lenova", Description = "Zarif Tasarim", StockQuantity = 6  },
                        new Product { Title = "Casper", Description = "Benzersiz Teknoloji", StockQuantity = 10  },
                        new Product { Title = "Monster", Description = "En İyi Oyun Kalitesi", StockQuantity = 11  },
                    }
                    
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
