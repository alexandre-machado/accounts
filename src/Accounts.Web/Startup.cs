using Accounts.Web.Controllers;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;

namespace HelloMvc
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole();

            //app.UseErrorPage();

            app.UseMvcWithDefaultRoute();

            //app.UseWelcomePage();

            //app.UseIdentity();

            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = ClaimsIdentityOptions.DefaultAuthenticationType,
            //    LoginPath = new PathString("/Account/Login"),
            //});

            app.UseCookieAuthentication(options =>
            {
                options.LoginPath = new PathString("/Account/Login");
                //options.LogoutPath = new PathString("/Account/Logout");
                //options.AutomaticAuthentication = true;
            }, "Application");
        }
    }
}