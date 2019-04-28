using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Hotel.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Hotel
{
    public class Startup  //см главу 14
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration["Data:HotelRooms:ConnectionString"]));
            services.AddTransient<IRoomRepository, EFRoomRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage(); 
            app.UseStatusCodePages();//Расширение ответов об ошибках
            app.UseStaticFiles();//обслуживание стратического содержимого из папки wwwroot
            app.UseSession();
            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //   name: null,
                //   template: "{quantity}/{category}/page{page:int}",
                //   defaults: new { controller = "Room", action = "List", page = 1 });
                //routes.MapRoute(
                //   name: null,
                //   template: "{quantity}/page{page:int}",
                //   defaults: new { controller = "Room", action = "List", page = 1 });
                //routes.MapRoute(
                //   name: null,
                //   template: "{category}/Page{page:int}",
                //   defaults: new { Controller = "Room", action = "List", page = 1 });
                //routes.MapRoute(
                //   name: null,
                //   template: "Page{page:int}",
                //   defaults: new { Controller = "Room", action = "List", page = 1 });
                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { Controller = "Room", action = "List", page = 1 });
                routes.MapRoute(name: null, template: "{controller}/{action}/{ id ?}");
            });
        }

    }
}
