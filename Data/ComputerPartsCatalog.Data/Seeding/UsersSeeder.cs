namespace ComputerPartsCatalog.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ComputerPartsCatalog.Common;
    using ComputerPartsCatalog.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            var admin = new ApplicationUser()
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
            };

            var user = new ApplicationUser()
            {
                Email = "user@gmail.com",
            };

            var password = "admin123";

            var role = await roleManager.FindByNameAsync(GlobalConstants.AdministratorRoleName);

            if (!userManager.Users.Any(x => x.Roles.Any(x => x.RoleId == role.Id)))
            {
                var result = await userManager.CreateAsync(admin, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, GlobalConstants.AdministratorRoleName);
                }
            }
        }
    }
}
