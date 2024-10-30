using AspNetCoreMvc2.Introduction.Identity;
using AspNetCoreMvc2.Introduction.Models;
using AspNetCoreMvc2.Introduction.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspNetCoreMvc2.Introduction
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<SchoolContext>(opts => opts.UseSqlServer(_configuration["DbConnection"]));
            services.AddDbContext<AppIdentityDbContext>(opts => opts.UseSqlServer(_configuration["DbConnection"]));

            services.AddIdentity<AppIdentityUser, AppIdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(opts =>
            {
                opts.Password.RequireDigit = true;
                opts.Password.RequireLowercase = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = true;
                opts.Password.RequireUppercase = true;


                opts.Lockout.MaxFailedAccessAttempts = 5;
                opts.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                opts.Lockout.AllowedForNewUsers = true;

                opts.User.RequireUniqueEmail = true;

                opts.SignIn.RequireConfirmedEmail = true;
                opts.SignIn.RequireConfirmedPhoneNumber = true;

            });


            services.ConfigureApplicationCookie(opts =>
            {
                opts.LoginPath = "/Secutiry/Login";
                opts.LogoutPath = "/Security/Logout";
                opts.AccessDeniedPath = "/Security/AccessDenied";
                opts.SlidingExpiration = true;
                opts.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".AspNetCoreDemo.Security.Cookie",
                    Path = "/",
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest,
                };
            });


            services.AddScoped<ICalculator, Calculator18>();
            services.AddScoped<ICalculator, Calculator8>();

            services.AddCors(opts =>
            {
                opts.AddPolicy("AllowAllOrigins", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });


            services.AddSession();

            services.AddDistributedMemoryCache();

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

            app.UseSession();

            app.UseCors("AllowAllOrigins");

            app.UseAuthentication();

            app.UseMvc(ConfigureRoutes);
        }

        private void ConfigureRoutes(IRouteBuilder routebuilder)
        {
            routebuilder.MapRoute("Default", "{controller=Filter}/{action=Index}/{id?}");
            routebuilder.MapRoute("MyRoute", "Baris/{controller=Home}/{action=Index3}/{id?}");

            routebuilder.MapRoute(
              name: "areas",
              template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

        }
    }
}
