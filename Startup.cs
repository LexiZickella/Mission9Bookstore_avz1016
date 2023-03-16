using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mission9Bookstore_avz1016.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9Bookstore_avz1016
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; set; }

        public Startup (IConfiguration temp)
        {
            Configuration = temp;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // add in the controllers with the views (use MVC pattern)
            services.AddControllersWithViews();

            // db context file 
            // set up the sqlite database
            services.AddDbContext<BookstoreContext> (options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BookDBConnection"]);
            });

            services.AddScoped<IBookstoreRepository,EFBookstoreRepository>();
            services.AddScoped<ICheckoutRepository, EFCheckoutRepository>();
            
            services.AddRazorPages();

            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddScoped<Basket>(x => SessionBasket.GetBasket(x));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Corresponds to the wwwroot folder
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("typepage",
                    "{booktype}/Page{pageNum}",
                    new { Controller = "Home", Action = "Index" });

                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "Page{pageNum}",
                    defaults: new { Controller = "Home", Action = "Index", pageNum = 1 });

                endpoints.MapControllerRoute("type",
                    "{bookType}",
                    new { Controller = "Home", Action = "Index", pageNum = 1 });

                // got to default controller route 
                endpoints.MapDefaultControllerRoute();
                // able to use Razor Pages
                endpoints.MapRazorPages();
            });
        }
    }
}
