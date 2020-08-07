using HobbyListForHobbyist.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyListForHobbyist.Models
{
    public class RoleInitializer
    {
        /// <summary>
        /// Roles Property which initializes the IdentityRoles
        /// </summary>
        private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
        {
            new IdentityRole{Name = ApplicationRoles.Admin, NormalizedName = ApplicationRoles.Admin.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString()},
            new IdentityRole{Name = ApplicationRoles.User, NormalizedName = ApplicationRoles.User.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString()}
        };

        /// <summary>
        /// Seed the database with the roles if they don't 
        /// </summary>
        /// <param name="serviceProvider">IServiceProvider Interface</param>
        /// <param name="users">UserManager<T> Object</param>
        /// <param name="_config">IConfiguration Interface</param>
        public static void SeedData(IServiceProvider serviceProvider, UserManager<ApplicationUser> users, IConfiguration _config)
        {
            using (var dbContext = new HobbyListDbContext(serviceProvider.GetRequiredService<DbContextOptions<HobbyListDbContext>>()))
            {
                dbContext.Database.EnsureCreated();
                AddRoles(dbContext);
                SeedUsers(users, _config);
            }
        }

        /// <summary>
        /// Seed the database with the Users if they don't exist.
        /// </summary>
        /// <param name="userManager">UserManager<T> Object</param>
        /// <param name="_config">IConfiguration Interface</param>
        public static void SeedUsers(UserManager<ApplicationUser> userManager, IConfiguration _config)
        {
            if (userManager.FindByEmailAsync(_config["AdminEmail"]).Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = _config["AdminEmail"];
                user.Email = _config["AdminEmail"];
                user.FirstName = "Stryker";
                user.LastName = "Coleman";

                IdentityResult result = userManager.CreateAsync(user, _config["AdminPassword"]).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, ApplicationRoles.Admin).Wait();
                }
            }

            if (userManager.FindByEmailAsync(_config["UserEmail"]).Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = _config["UserEmail"];
                user.Email = _config["UserEmail"];
                user.FirstName = "Robert";
                user.LastName = "SpaceMarine";

                IdentityResult result = userManager.CreateAsync(user, _config["UserEmail"]).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, ApplicationRoles.User).Wait();
                }
            }
        }

        /// <summary>
        /// Helper Method which adds roles
        /// </summary>
        /// <param name="context">HobbyListDbContext Object</param>
        private static void AddRoles(HobbyListDbContext context)
        {
           if (context.Roles.Any()) 
                return;

            foreach (var role in Roles)
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }
    }
}
