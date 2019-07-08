using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ManagerPro
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Web",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AccountManager", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "Account",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AccountCreate", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "VhostAccount",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "VhostAccount", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Login",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Authentication", action = "Login", id = UrlParameter.Optional }
           );
        }
    }
}
