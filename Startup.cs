using AspNetCoreMvc2.Introduction.Models;
using AspNetCoreMvc2.Introduction.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreMvc2.Introduction
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var connection = @"Server=(localdb)\MSSQLLocalDB; Database=SchoolDb; Trusted_Connection=true";
            services.AddDbContext<SchoolContext>(opts => opts.UseSqlServer(connection));

            services.AddScoped<ICalculator, Calculator18>();
            services.AddScoped<ICalculator, Calculator8>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            env.EnvironmentName = EnvironmentName.Production;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
            //app.UseMvc(routes =>
            //{
            //	routes.MapRoute(
            //		name: "default",
            //		template: "{controller=home}/{action=index}/{id?}"
            //		);
            //});

            app.UseMvc(ConfigureRoutes);
        }

        private void ConfigureRoutes(IRouteBuilder routebuilder)
        {
            routebuilder.MapRoute("Default", "{controller=Filter}/{action=Index}/{id?}");
            routebuilder.MapRoute("MyRoute", "Baris/{controller=Home}/{action=Index3}/{id?}");
        }
    }
}
