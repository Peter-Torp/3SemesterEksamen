using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Auction_House_MVC
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
                name: "SignUp",
                url: "{controller}/{action}",
                defaults: new { controller = "User", action = "SignUp" }
            );

            routes.MapRoute(
                name: "Auctions",
                url: "{controller}/{action}",
                defaults: new { controller = "Auction", action = "Auctions" }
                );

            routes.MapRoute(
                name: "MyAccount",
                url: "{controller}/{action}",
                defaults: new { controller = "User", action = "MyAccount" }
                );

            routes.MapRoute(
                name: "LogOut",
                url: "{controller}/{action}",
                defaults: new { controller = "User", action = "LogOut" }
                );

            routes.MapRoute(
                name: "Auction",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Auction", action = "Auction", id = UrlParameter.Optional }
                );
        }
    }
}
