using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCCalendar
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Next",
                "next",
                new { controller = "Home", action = "Next" }
            );

            routes.MapRoute(
                "Prev",
                "prev",
                new { controller = "Home", action = "Prev" }
            );

            routes.MapRoute(
                "Add",
                "add",
                new { controller = "Home", action = "Add" }
            );
        }
    }
}
