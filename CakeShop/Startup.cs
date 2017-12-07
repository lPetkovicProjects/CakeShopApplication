using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CakeShop.Data.Interfaces;
using CakeShop.Data;
using Microsoft.EntityFrameworkCore;
using CakeShop.Data.Repositories;
using CakeShop.Data.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;


namespace CakeShop
{
    public class Startup
    {

        private IConfigurationRoot _configurationRoot;
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }


       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CakeDbContext>(options => options.UseSqlServer(_configurationRoot.GetConnectionString("CakeDatabase")));

          
            services.AddTransient<ICakeRepository,CakeRepository>();
            services.AddTransient<ICategoryRepository,CategoryRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => Cart.GetCart(sp));
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,CakeDbContext context)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            



            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "drinkdetails",
                   template: "Drink/Details/{drinkId?}",
                   defaults: new { Controller = "Drink", action = "Details" });

                routes.MapRoute(
                    name: "categoryfilter",
                    template: "Cake/{action}/{category?}",
                    defaults: new { Controller = "Cake", action = "List" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{Id?}");
            });

            DbInitializer.Initialize(context);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //        app.UseBrowserLink();
        //    }
        //    else
        //    {
        //        app.UseExceptionHandler("/Home/Error");
        //    }

        //    app.UseStaticFiles();

        //    DbInitializer.Seed(app);
        //    app.UseMvc(routes =>
        //    {
        //        routes.MapRoute(
        //            name: "default",
        //            template: "{controller=Home}/{action=Index}/{id?}");
        //    });
        //}
    }
}
