namespace ComputerPartsCatalog.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ComputerPartsCatalog.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "CPU" });
            await dbContext.Categories.AddAsync(new Category { Name = "VIDEOCARD" });
            await dbContext.Categories.AddAsync(new Category { Name = "MOTHERBOARD" });
            await dbContext.Categories.AddAsync(new Category { Name = "RAM" });
            await dbContext.Categories.AddAsync(new Category { Name = "HDD" });
            await dbContext.Categories.AddAsync(new Category { Name = "COOLER" });
            await dbContext.Categories.AddAsync(new Category { Name = "CASE" });
            await dbContext.Categories.AddAsync(new Category { Name = "MONITOR" });
            await dbContext.Categories.AddAsync(new Category { Name = "MOUSE" });
            await dbContext.Categories.AddAsync(new Category { Name = "KEYBOARD" });
            await dbContext.Categories.AddAsync(new Category { Name = "COMPUTER" });
            await dbContext.Categories.AddAsync(new Category { Name = "LAPTOP" });

            await dbContext.SaveChangesAsync();
        }
    }
}
