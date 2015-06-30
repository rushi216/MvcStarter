using MvcStarter.App_Start;
using MvcStarter.Models;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(MvcStarter.Startup))]
namespace MvcStarter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = AutofacConfig.RegisterDependancies(app);
            
            DatabaseConfig.Initialize(container);

            ConfigureAuth(app);
        }
    }
}
