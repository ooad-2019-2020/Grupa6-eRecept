using eRecept.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using eRecept.Repositories;

namespace eRecept
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            System.Diagnostics.Debug.WriteLine("Ovdje now");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddDbContext<Repositories.UserRepository>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DevConnection1")));

            services.AddDbContext<Repositories.IngredientRepository>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DevConnection1")));

            services.AddDbContext<Repositories.RecipeRepository>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DevConnection1")));

            services.AddDbContext<Repositories.RecipeIngredientRepository>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DevConnection1")));

            services.AddDbContext<Repositories.SavedRecipesRepository>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DevConnection1")));

            services.AddDbContext<Repositories.FeedbackRepository>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DevConnection1")));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            System.Console.Write("Am here");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
