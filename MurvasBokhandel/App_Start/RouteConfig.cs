using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MurvasBokhandel
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Public", action = "Start", id = UrlParameter.Optional },
                namespaces: new[] { "MurvasBokhandel.Controllers" }
            );

            routes.MapRoute(
                name: "Book",
                url: "{controller}/{action}/{isbn}",
                defaults: new { controller = "Book", action = "GetBook", isbn = UrlParameter.Optional },
                namespaces: new[] { "MurvasBokhandel.Controllers" }
            );

            routes.MapRoute(
                name: "AuthorAdmin",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AuthorAdmin", action = "Start", id = UrlParameter.Optional },
                namespaces: new[] { "MurvasBokhandel.Controllers" }
            );

            routes.MapRoute(
                name: "BorrowerAdmin",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "BorrowerAdmin", action = "Start", id = UrlParameter.Optional },
                namespaces: new[] { "MurvasBokhandel.Controllers" }
            );

            routes.MapRoute(
                name: "BookAdmin",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "BorrowerAdmin", action = "Start", id = UrlParameter.Optional },
                namespaces: new[] { "MurvasBokhandel.Controllers" }
            );

            routes.MapRoute(
                name: "Auth",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Auth", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "MurvasBokhandel.Controllers" }
            );

            routes.MapRoute(
                name: "Api",
                url: "Api/{controller}/{action}/{id}",
                namespaces: new[] { "MurvasBokhandel.Controllers.Api" }
            );

            routes.MapRoute(
                name: "Error",
                url: "{controller}/{action}/{id}",
                namespaces: new[] { "MurvasBokhandel.Controllers" }
            );
        }
    }
}
