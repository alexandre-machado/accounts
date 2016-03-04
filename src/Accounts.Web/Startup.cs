using Accounts.Web.Models;
using Accounts.Web.Services;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc;
using Accounts.Web.Services.UserImageProviders;
using Swashbuckle.SwaggerGen;

namespace Accounts.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddCaching();
            services.AddSession();

            services.AddSwaggerGen();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<MvcOptions>(options =>
            {
                //options.RespectBrowserAcceptHeader = true;
            });
            services.AddEntityFramework()
                .AddInMemoryDatabase()
                .AddDbContext<ApplicationDbContext>(options => { options.UseInMemoryDatabase(); });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<ApplicationUserManager>();
            services.AddTransient<ApplicationSignInManager>();
            services.AddTransient<IUserImageProvider, SharePointProvider>();

            services.AddAuthentication();
        }

        public IConfigurationRoot Configuration { get; set; }

        public void Configure(
            IApplicationBuilder app
            , IHostingEnvironment env
            , ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // Add the following to the request pipeline only in development environment.
            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage(o => o.EnableAll());
            }
            else
            {
                // Add Error handling middleware which catches all application specific errors and
                // sends the request to the following path or controller action.
                app.UseExceptionHandler("/Home/Error");
            }

            // Add the platform handler to the request pipeline.
            app.UseIISPlatformHandler(options => options.AuthenticationDescriptions.Clear());

            // Add static files to the request pipeline.
            app.UseStaticFiles();

            // Add cookie-based authentication to the request pipeline.
            app.UseIdentity();

            //app.UseCookieAuthentication(options =>
            //{
            //    //options.AutomaticAuthenticate = true;
            //    options.AccessDeniedPath = new PathString("/Account/AccessDenied");
            //    options.LoginPath = new PathString("/Account/Login");
            //    options.LogoutPath = new PathString("/Account/Logout");
            //});

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute("subarearoute", "{area:exists}/{subarea:exists}/{controller=Home}/{action=Index}");
                routes.MapRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}");
                routes.MapRoute("controllerActionRoute", "{controller=Home}/{action=Index}");
            });

            app.UseSwaggerGen();
            app.UseSwaggerUi();
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}