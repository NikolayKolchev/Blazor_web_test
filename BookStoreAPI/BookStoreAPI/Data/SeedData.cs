using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Data
{
    public static class SeedData
    {
        public async static Task Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedUsers(userManager);
            await SeedRoles(roleManager);
        }

        private async static Task SeedUsers(UserManager<IdentityUser> userManager)
        {
            if(await userManager.FindByEmailAsync("adming@bookstore.com") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "Admin",
                    Email = "admin@bookstore.com"
                };

                var result = await userManager.CreateAsync(user, "P@ssword!12");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Administrator");
                }
            }

            if (await userManager.FindByEmailAsync("customer1@abv.com") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "Customer1",
                    Email = "customer1@abv.com"
                };

                var result = await userManager.CreateAsync(user, "P@ssword!12");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Customer");
                }
            }

            if (await userManager.FindByEmailAsync("customer2@abv.com") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "Customer2",
                    Email = "customer2@abv.com"
                };

                var result = await userManager.CreateAsync(user, "P@ssword!12");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Customer");
                }
            }
        }

        private async static Task SeedRoles(RoleManager<IdentityRole> roleManger)
        {
            if (!await roleManger.RoleExistsAsync("Administrator"))
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };

                await roleManger.CreateAsync(role);
            }

            if (!await roleManger.RoleExistsAsync("Customer"))
            {
                var role = new IdentityRole
                {
                    Name = "Customer"
                };

                await roleManger.CreateAsync(role);
            }
        }
    }
}
