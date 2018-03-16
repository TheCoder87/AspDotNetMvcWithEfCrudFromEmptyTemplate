using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;

namespace AspDotNetMvcWithEfCrudFromEmptyTemplate.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/auth/login")
            });
        }
    }
}