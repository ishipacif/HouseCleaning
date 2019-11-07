using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseCleanersApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Design;
using  Microsoft.EntityFrameworkCore;
using Seeder = HouseCleanersApi.Data.Seeder;

namespace HouseCleanersApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            
            services.AddControllers();
            // Add framework services.
            services.AddDbContext<clearnersDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("NpgsqlConnection")));

           services.AddIdentity<User, IdentityRole>(cfg => { cfg.User.RequireUniqueEmail = true; })
              .AddEntityFrameworkStores<clearnersDbContext>()
               ;

            services.AddTransient<Seeder>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                 {
                     var seeder = scope.ServiceProvider.GetService<Seeder>();
                     seeder.Seed().Wait();
                 }
                 app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseEndpoints(endpoints =>
            { 
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
            
        }
    }
}
