using HobbyListForHobbyist.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyListForHobbyist.Data
{
    public class HobbyListDbContext : IdentityDbContext<ApplicationUser>
    {
        public HobbyListDbContext(DbContextOptions<HobbyListDbContext> options) : base(options)
        {
            // Intentially left Blank
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ============= TODO declare JoinTable's compositeKeys here ============================
            // Example: modelBuilder.Entity<MiniToPaint().HasKey(x => new { x.MiniModelId, x.PaintId });
            
            // ======== TODO seed the database with info here ======================
            // Example: modelBuilder.Entity<MiniModel>().HasData(new MiniModel {...});
        }

        // ================ TODO Connect the DB with the model classes. 
        // example:  DbSet<MiniModel> MiniModels { get; set; }
    }
}
