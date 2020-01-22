using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CompanyWebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Company", action = "ListeEmp", id = UrlParameter.Optional }
            );
            routes.MapRoute(
            name: "Pagination",
            url: "{controller}/{action}/{page}-{size=5}",
            defaults: new { controller = "Company", action = "ListeCat", page = UrlParameter.Optional }
            );            
            routes.MapRoute(
            name: "Pagination2",
            url: "{controller}/{action}/{page}-{size=5}",
            defaults: new { controller = "Company", action = "ListeEmp", page = UrlParameter.Optional }
            );            
            routes.MapRoute(
            name: "Pagination3",
            url: "{controller}/{action}/{page}-{size=5}",
            defaults: new { controller = "Company", action = "ListeDeprt", page = UrlParameter.Optional }
            );
        }
    }
}
