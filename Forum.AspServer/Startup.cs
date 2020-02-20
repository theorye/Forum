using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.AspServer.Models;
using Forum.AspServer.Services;
using Forum.AspServer.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Forum.AspServer
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
            // For the configuration to be dependency injected into services, 
            // we need to add services.AddOptions()
            services.AddOptions();

            // We also need to tell .NET Core what to focus on when loading the 
            // configuration settings from appsettings.JSON so we point a 
            // DataConnection object to the app settings section called DataConnection.
            services.Configure<DataConnection>(Configuration.GetSection("DataConnection"));


            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();


            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IForumService, ForumService>();
            services.AddTransient<IUserService, UserService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=User}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
