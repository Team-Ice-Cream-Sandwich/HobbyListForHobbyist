using HobbyListForHobbyist.Models;
using HobbyListForHobbyist.Models.Interfaces;
using HobbyListForHobbyist.Models.Services;
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
    class DatabaseTestClass
    {
    }
}
