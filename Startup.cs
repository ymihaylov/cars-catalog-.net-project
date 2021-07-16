using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CarsCatalog.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace CarsCatalog
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
            services.AddDbContext<CarsCatalogContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MyDatabase")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<CarsCatalogContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                
                endpoints.MapControllerRoute(
                    name: "car_models",
                    pattern: "car_models/{id:int}",
                    defaults: new { controller = "Home", action = "CarModels", });

                endpoints.MapControllerRoute(
                    name: "show_car",
                    pattern: "show_car/{id:int}",
                    defaults: new { controller = "Home", action = "ShowCar", });

                endpoints.MapControllerRoute(
                    name: "search",
                    pattern: "search",
                    defaults: new { controller = "Home", action = "Search", });

                endpoints.MapControllerRoute(
                    name: "CarModels.ChangeCommentStatus",
                    pattern: "/CarModels/ChangeCommentStatus",
                    defaults: new { controller = "CarModels", action = "ChangeCommentStatus", });

                endpoints.MapControllerRoute(
                    name: "CarModels.DeletePhoto",
                    pattern: "/CarModels/DeletePhoto",
                    defaults: new { controller = "CarModels", action = "DeletePhoto", });

                endpoints.MapControllerRoute(
                    name: "post_a_comment",
                    pattern: "post_a_comment",
                    defaults: new { controller = "Home", action = "PostAComment", });

                endpoints.MapControllerRoute(
                    name: "admin.car_models.list",
                    pattern: "admin/car_models_list",
                    defaults: new { controller = "Admin", action = "CarModels", });

                endpoints.MapControllerRoute(
                    name: "CarModels",
                    pattern: "CarModels",
                    defaults: new { controller = "CarModels", action = "CarModels", });


                endpoints.MapRazorPages();

                //endpoints.MapGet("/car_models/{car_make_id:int}", async context =>
                //{
                //    var carMakeId = context.Request.RouteValues["car_make_id"];
                //    await context.Response.WriteAsync($"Hello {carMakeId}!");
                //});
            });
        }
    }
}
