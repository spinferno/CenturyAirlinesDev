using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using System.Data.Entity;
using CenturyAirlines.Entities;

namespace CenturyAirlines
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Database.SetInitializer<ApplicationDBContext>(new DropCreateDatabaseIfModelChanges<ApplicationDBContext>());
        }
    }
}
