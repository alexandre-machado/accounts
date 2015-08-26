using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;

namespace accounts
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddCaching();
            services.AddSession();

            services.AddAuthentication();
            //services.ConfigureCookieAuthentication(options =>
            //{
            //    options.AccessDeniedPath = new PathString("/Account/AccessDenied");
            //    options.LoginPath = new PathString("/Account/Login");
            //    options.LogoutPath = new PathString("/Account/Logout");
            //    options.AutomaticAuthentication = true;
            //});
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            //app.UseSession();
            //app.UseStaticFiles();

            //app.UseErrorPage();

            //app.UseMvcWithDefaultRoute();

            //app.UseWelcomePage();

            //app.UseIdentity();


            app.UseCookieAuthentication(options =>
            {
                options.AutomaticAuthentication = true;

                options.AccessDeniedPath = new PathString("/Account/AccessDenied");
                options.LoginPath = new PathString("/Account/Login");
                options.LogoutPath = new PathString("/Account/Logout");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller}/{action}",
                    defaults: new { action = "Index" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });

                routes.MapRoute(
                    name: "api",
                    template: "{controller}/{id?}");
            });
        }
    }
}