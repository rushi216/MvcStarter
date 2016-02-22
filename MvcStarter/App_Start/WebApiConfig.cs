using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MvcStarter
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //We include this to bypass cookie(host) authentication, so it cant process webapi request for authentication/authorization
            //This also helps to return 401 instead of login page when cookie authentication comes in between
            //But currently it is commented as we want to authorize webapi request also with cookies
            //But by commenting this it will return login page instead of 401 while webapi, so for that I have overrided cookie authentication config
            

            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
