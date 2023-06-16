using Microsoft.AspNetCore.Identity;
using System.Data;

namespace Ordersystem.Web.Helper
{
    public class SeedDataBaseHelper
    {
        public static async Task Seed(IServiceProvider service)
        {
            //Seed Roles
            var userManager = service.GetService<UserManager<IdentityUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            ////Add two roles
            await roleManager.CreateAsync(new IdentityRole(Ordersystem.DataObjects.ApplicationRoles.Role_Admin));
            await roleManager.CreateAsync(new IdentityRole(Ordersystem.DataObjects.ApplicationRoles.Role_Customer));
            await roleManager.CreateAsync(new IdentityRole(Ordersystem.DataObjects.ApplicationRoles.Role_Employee));
            //await roleManager.CreateAsync(new IdentityRole(Ordersystem.DataObjects.ApplicationRoles.Role_Company));


            // Creating admin

            var user = new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                PhoneNumber = "0123456789",


            };
            var userInDb = await userManager.FindByEmailAsync(user.Email);
            if (userInDb == null)
            {
                await userManager.CreateAsync(user, "Testing*123");
                await userManager.AddToRoleAsync(user, Ordersystem.DataObjects.ApplicationRoles.Role_Admin);
            }
        }
    }
}
