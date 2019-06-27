using Capstone.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class SeededData
    {
        public static async Task Initialize(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            String adminId1 = "";
            String adminId2 = "";

            string role1 = "Admin";
            string desc1 = "This is the admin role";

            string role2 = "Employee";
            string desc2 = "This is the employees role";

            string password = "T3ster!";

            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role1, desc1, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role2, desc2, DateTime.Now));
            }
            if (await userManager.FindByNameAsync("test@test.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "test@test.com",
                    Email = "test@test.com",
                    FirstName = "Matt",
                    LastName = "Washington",
                    Street = "1234 N 1st Street",
                    City = "Milwaukee",
                    State = "WI",
                    Zipcode = "53208",
                    PhoneNumber = "987654321"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId1 = user.Id;
            }

            if (await userManager.FindByNameAsync("aa@aa.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "aa@aa.com",
                    Email = "aa@aa.com",
                    FirstName = "Brice",
                    LastName = "Mathews",
                    Street = "5678 S 2nd Street",
                    City = "Greenfield",
                    State = "WI",
                    Zipcode = "53129",
                    PhoneNumber = "123456789"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }
                adminId2 = user.Id;
            }

            if (await userManager.FindByNameAsync("bb@bb.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "bb@bb.com",
                    Email = "bb@bb.com",
                    FirstName = "Luke",
                    LastName = "Minturn",
                    Street = "3456 E 3rd Street",
                    City = "Brookfield",
                    State = "WI",
                    Zipcode = "53008",
                    PhoneNumber = "456789123"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }
            }

            if (await userManager.FindByNameAsync("cc@cc.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "cc@cc.com",
                    Email = "cc@cc.com",
                    FirstName = "Rory",
                    LastName = "Houlihan",
                    Street = "9645 W 4th Street",
                    City = "Oak Creek",
                    State = "WI",
                    Zipcode = "53154",
                    PhoneNumber = "765432189"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }
            }
        }
    }
}

