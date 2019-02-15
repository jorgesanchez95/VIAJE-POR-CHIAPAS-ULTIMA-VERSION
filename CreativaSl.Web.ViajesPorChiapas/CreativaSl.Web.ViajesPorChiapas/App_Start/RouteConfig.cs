using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CreativaSl.Web.ViajesPorChiapas
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "Robots.txt",
            //    "robots.txt",
            //    new { controller = "robots", action = "robotstext" }
            //);

            routes.MapRoute(
                "sitemap.xml",
                "sitemap.xml",
                new { controller = "sitemap", action = "index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "home", action = "index", id = UrlParameter.Optional }
            );
        }
    }
}
