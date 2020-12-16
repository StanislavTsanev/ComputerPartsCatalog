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

            //var admin = new ApplicationUser()
            //{
            //    UserName = "admin@gmail.com",
            //    Email = "admin@gmail.com",
            //};

            //var user = new ApplicationUser()
            //{
            //    Email = "user@gmail.com",
            //};

            //var password = "admin123";

            //var role = await roleManager.FindByNameAsync(GlobalConstants.AdministratorRoleName);

            //if (!userManager.Users.Any(x => x.Roles.Any(x => x.RoleId == role.Id)))
            //{
            //    var result = await userManager.CreateAsync(admin, password);

            //    if (result.Succeeded)
            //    {
            //        await userManager.AddToRoleAsync(admin, GlobalConstants.AdministratorRoleName);
            //    }
            //}

            // Create Admin
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountsSeeding.AdminEmail,
                GlobalConstants.AdministratorRoleName);

            // Create User
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountsSeeding.UserEmail);

        }

        private static async Task CreateUser(
            UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, string email, string roleName = null)
        {
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
            };

            var password = GlobalConstants.AccountsSeeding.Password;

            if (roleName != null)
            {
                var role = await roleManager.FindByNameAsync(roleName);

                if (!userManager.Users.Any(x => x.Roles.Any(x => x.RoleId == role.Id)))
                {
                    var result = await userManager.CreateAsync(user, password);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, roleName);
                    }
                }
            }
            else
            {
                if (!userManager.Users.Any(x => x.Roles.Count() == 0))
                {
                    var result = await userManager.CreateAsync(user, password);
                }
            }
        }
    }
}
