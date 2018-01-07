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
                "{controller}/{action}",
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
                "add/{month}/{day}",
                new { controller = "Home", action = "Add", month = UrlParameter.Optional, day = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Edit",
                "edit/{guid}",
                new { controller = "Home", action = "Edit", guid = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Delete",
                "delete/{guid}",
                new { controller = "Home", action = "Delete", guid = UrlParameter.Optional }
            );
        }
    }
}
