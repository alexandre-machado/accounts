using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;

namespace HelloMvc
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.ConfigureCookieAuthentication(options =>
            {
                options.AccessDeniedPath = new PathString("/Account/AccessDenied");
                options.LoginPath = new PathString("/Account/Login");
                //options.LogoutPath = new PathString("/Account/Logout");
                //options.AutomaticAuthentication = true;
            });

            services.AddCaching();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole();

            app.UseSession();
            app.UseStaticFiles();

            //app.UseErrorPage();

            app.UseMvcWithDefaultRoute();

            //app.UseWelcomePage();

            app.UseIdentity();

            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = ClaimsIdentityOptions.DefaultAuthenticationType,
            //    LoginPath = new PathString("/Account/Login"),
            //});

            //app.UseCookieAuthentication(options =>
            //{
            //    options.AccessDeniedPath = new PathString("/Account/AccessDenied");
            //    options.LoginPath = new PathString("/Account/Login");
            //    //options.LogoutPath = new PathString("/Account/Logout");
            //    //options.AutomaticAuthentication = true;
            //}, "Application");

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