using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
[assembly: OwinStartup(typeof(FinalAssignment.Startup))]

namespace FinalAssignment
{ 
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions() { AuthenticationType=DefaultAuthenticationTypes.ApplicationCookie,LoginPath=new PathString("/Users/Login")});
        }
    }
}
