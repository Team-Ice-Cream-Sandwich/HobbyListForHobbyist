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
            // Intentionally left Blank
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MiniToPaint>().HasKey(x => new { x.MiniModelId, x.PaintId });
            modelBuilder.Entity<MiniToSupply>().HasKey(x => new { x.MiniModelId, x.SupplyId });

            modelBuilder.Entity<MiniModel>().HasData(
                 new MiniModel
                {
                    Id = 1,
                    Name = "Platoon Leader",
                    Manufacturer = "Forge Fire",
                    PartNumber = "111",
                    Faction = "North Army",
                    PointCost = 100,
                    BuildState = BuildState.built
                },
                 new MiniModel
                 {
                    Id = 2,
                    Name = "Heavy Support Squad",
                    Manufacturer = "Forge Fire",
                    PartNumber = "122",
                    Faction = "South Army",
                    PointCost = 75,
                    BuildState = BuildState.painted
                },
                  new MiniModel
                  {
                      Id = 3,
                      Name = "Chariot Armored Personnel Carrier",
                      Manufacturer = "Forge Fire",
                      PartNumber = "122",
                      Faction = "East Army",
                      PointCost = 250,
                      BuildState = BuildState.unBuilt
                  });
            modelBuilder.Entity<Paint>().HasData(
                new Paint 
                {
                    Id = 1,
                    ColorName = "Gunmetal",
                    Manufacturer = "Forge Fire",
                    ProductNumber = "32"
                },
                new Paint
                {
                    Id = 2,
                    ColorName = "Patriot Green",
                    Manufacturer = "Forge Fire",
                    ProductNumber = "44"
                },
                new Paint
                {
                    Id = 3,
                    ColorName = "Alabaster",
                    Manufacturer = "Forge Fire",
                    ProductNumber = "78"
                }
                );

        }

        public DbSet<MiniModel> MiniModels { get; set; }
        public DbSet<MiniToPaint> MinisToPaint { get; set; }
        public DbSet<MiniToSupply> MinisToSupply { get; set; }
        public DbSet<Paint> Paints { get; set; }
        public DbSet<Supply> Supply { get; set; }
    }
}
