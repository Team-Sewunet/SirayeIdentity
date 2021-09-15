using Microsoft.AspNetCore.Identity;
using Siraye.Application.Enums;
using Siraye.Infrastructure.Identity.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Siraye.Infrastructure.Identity.Seeds
{
    public static class DefaultBasicUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "Sewunet",
                Email = "Sewunet92@gmail.com",
                FirstName = "Sewunet",
                LastName = "Abebaw",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                }

            }
        }
    }
}
