using MvcStarter.Identity;
using MvcStarter.Models;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MvcStarter.App_Start
{
    public class AutofacConfig
    {
        public static IComponentContext RegisterDependancies(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            // REGISTER DEPENDENCIES
            builder.RegisterType<ApplicationDbContext>().AsSelf();
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>();
            builder.RegisterType<ApplicationUserManager>().AsSelf();
            builder.RegisterType<ApplicationSignInManager>().AsSelf();
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication);
            builder.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider());

            // register mvc controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // register webapi controller
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();

            // replace mvc dependancy resolver with autofac
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // replace webapi dependancy resolver with autofac
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }
    }
}