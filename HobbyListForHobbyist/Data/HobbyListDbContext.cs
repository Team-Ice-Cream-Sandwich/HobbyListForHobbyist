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
            // IntentC:\Users\yasmo\Source\Repos\HobbyListForHobbyist\HobbyListForHobbyist\Data\HobbyListDbContext.csionally left Blank
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
                     BuildState = BuildState.built,
                     Email = "admin@gmail.com"
                 },
                 new MiniModel
                 {
                     Id = 2,
                     Name = "Heavy Support Squad",
                     Manufacturer = "Forge Fire",
                     PartNumber = "122",
                     Faction = "South Army",
                     PointCost = 75,
                     BuildState = BuildState.painted,
                     Email = "admin@gmail.com"
                 },
                  new MiniModel
                  {
                      Id = 3,
                      Name = "Chariot Armored Personnel Carrier",
                      Manufacturer = "Forge Fire",
                      PartNumber = "122",
                      Faction = "East Army",
                      PointCost = 250,
                      BuildState = BuildState.unBuilt,
                      Email = "admin@gmail.com"
                  });
            modelBuilder.Entity<Paint>().HasData(
                new Paint
                {
                    Id = 1,
                    ColorName = "Gunmetal",
                    Manufacturer = "Forge Fire",
                    ProductNumber = "32",
                    Email = "admin@gmail.com"
                },
                new Paint
                {
                    Id = 2,
                    ColorName = "Patriot Green",
                    Manufacturer = "Forge Fire",
                    ProductNumber = "44",
                    Email = "admin@gmail.com"
                },
                new Paint
                {
                    Id = 3,
                    ColorName = "Alabaster",
                    Manufacturer = "Forge Fire",
                    ProductNumber = "78",
                    Email = "admin@gmail.com"
                }
                );
            modelBuilder.Entity<Supply>().HasData(
                new Supply
                {
                    Id = 1,
                    Name = "Snipps",
                    Category = "Cutting",
                    Email = "admin@gmail.com"
                },
                new Supply
                {
                    Id = 2,
                    Name = "Plastiweld",
                    Category = "Glue",
                    Email = "admin@gmail.com"
                }
                );
            modelBuilder.Entity<MiniWishList>().HasData(
                new MiniWishList
                {

                    Id = 1,
                    Name = "Chariot Personnel Carrier",
                    Manufacturer = "Forge Fire",
                    PartNumber = "200",
                    Faction = "East Army",
                    PointCost = 250,
                    Price = 20.00m,
                    Email = "admin@gmail.com"
                },
                 new MiniWishList
                 {

                     Id = 2,
                     Name = "Heavy support Squad",
                     Manufacturer = "Forge Fire",
                     PartNumber = "300",
                     Faction = "West Army",
                     PointCost = 250,
                     Price = 35.00m,
                     Email = "admin@gmail.com"
                 },
                  new MiniWishList
                  {

                      Id = 3,
                      Name = "Chariot Armed Personnel Carrier",
                      Manufacturer = "Forge Fire",
                      PartNumber = "30",
                      Faction = "North Army",
                      PointCost = 250,
                      Price = 10m,
                      Email = "admin@gmail.com"
                  }
                );

        }

        public DbSet<MiniModel> MiniModels { get; set; }
        public DbSet<MiniWishList> MiniWishLists { get; set; }
        public DbSet<MiniToPaint> MinisToPaint { get; set; }
        public DbSet<MiniToSupply> MinisToSupply { get; set; }
        public DbSet<Paint> Paints { get; set; }
        public DbSet<Supply> Supplies { get; set; }
    }
}
