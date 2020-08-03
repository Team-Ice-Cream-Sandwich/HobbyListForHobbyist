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
        // ============= TODO build list of roles ======================
        private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
        {
            new IdentityRole{Name = ApplicationRoles.Admin, NormalizedName = ApplicationRoles.Admin.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString()},
            new IdentityRole{Name = ApplicationRoles.User, NormalizedName = ApplicationRoles.User.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString()}
        };

        // ================ TODO Build SeedData method =====================
        public static void SeedDate(IServiceProvider serviceProvider, UserManager<ApplicationUser> users, IConfiguration _config)
        {
            using (var dbContext = new HobbyListDbContext(serviceProvider.GetRequiredService<DbContextOptions<HobbyListDbContext>>()))
            {
                dbContext.Database.EnsureCreated();
                AddRoles(dbContext);
                seedUsers(users, _config);
            }
        }

        // ================== TODO build SeedUser Method ======================
        public static void SeedUsers(UserManager<ApplicationUser> userManager, IConfiguration _config)
        {
            if (userManager.FindByEmailAsync(_config["AdminEmail"]).Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = _config["AdminEmail"];
                user.Email = _config["AdminEmail"];
                user.FirstName = "Yasir";
                user.LastName = "Stubbs";

                IdentityResult result = userManager.CreateAsync(user, _config["AdminPassword"]).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, ApplicationRoles.Admin).Wait();
                }
            }

            if (userManager.FindByEmailAsync(_config[""]))
        }

        // ===================== TODO build AddRoles Method ==========================
    }
}
