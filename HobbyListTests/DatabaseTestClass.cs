using HobbyListForHobbyist.Data;
using HobbyListForHobbyist.Models;
using HobbyListForHobbyist.Models.Interfaces;
using HobbyListForHobbyist.Models.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HobbyListTests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection service)
        {
            service.AddTransient<IMiniModel, MiniModelService>();
            service.AddTransient<IMiniWishList, MiniWishListService>();
            service.AddTransient<IPaint, PaintService>();
            service.AddTransient<ISupply, SupplyService>();            
        }
    }
    public class DatabaseTestBase : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly HobbyListDbContext _db;
        protected readonly IMiniModel _miniModel;
        protected readonly IMiniWishList _miniWishList;
        protected readonly IPaint _paint;
        protected readonly ISupply _supply;

        public DatabaseTestBase()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new HobbyListDbContext(
                new DbContextOptionsBuilder<HobbyListDbContext>()
                .UseSqlite(_connection)
                .Options);

            _db.Database.EnsureCreated();

            _paint = new PaintService(_db);

            _supply = new SupplyService(_db);

            _miniModel = new MiniModelService(_db, _paint, _supply);            
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }
    }
}
