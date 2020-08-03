using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HobbyListForHobbyist.Data;
using HobbyListForHobbyist.Models;
using HobbyListForHobbyist.Models.Interfaces;
using HobbyListForHobbyist.Models.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HobbyListForHobbyist
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // ========================= TODO Install Newtonsoft into project then uncomment ======================
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            // =============================  TODO Uncomment when DbContext is built
            services.AddDbContext<HobbyListDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            // ============================== TODO Install and use Identity ==================================
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<HobbyListDbContext>()
                    .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                // Must define the JWT Bearer defaults
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                // Define the JwtBearer's parameters
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JWTIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWTKey"]))
                };
            });

            // ======================== TODO Change the name of the roles ============================
            //// add my policies
            services.AddAuthorization(options =>
            {
                options.AddPolicy("TopLevelPrivileges", policy => policy.RequireRole(ApplicationRoles.Admin));
                options.AddPolicy("GenericPrivileges", policy => policy.RequireRole(ApplicationRoles.Admin, ApplicationRoles.User)); 
            });

            services.AddTransient<IMiniModel, MiniModelService>();
            services.AddTransient<IPaint, PaintService>();
            services.AddTransient<ISupply, SupplyService>();         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            // ====================== TODO Build out ApplicationUser Class ======================
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // ====================== TODO Build out RoleInitializer Class ======================
            RoleInitializer.SeedData(serviceProvider, userManager, Configuration);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
