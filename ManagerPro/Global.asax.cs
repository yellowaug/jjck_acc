using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ManagerPro.DAL;
using System.Data.Entity.Infrastructure.Interception;

namespace ManagerPro
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DbInterception.Add(new SchoolInterceptorLogging());
            DbInterception.Add(new SchoolInterceptorTransientErrors());
        }
    }
}
