using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VidlyProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*Attribute route: this a much like custom route but
             short and easier to maintain*/
            routes.MapMvcAttributeRoutes();
            
            //custom route
            /*this always comes before the default route in this order:
             from most specific(custom) to most generic(default)
             for maintaiance purpose this route actions needs to
             be update manually whenthe controller is updated/changed*/
            
            /*routes.MapRoute(
                //name
                "MoviesByReleaseDate",
                //url pattern
                "movies/released/{year}/{month}",
                //default argument
                new { Controller = "Movies", action = "ByReleaseDate"},
                new { year = @"\d{4}", month = @"\d{2}"});*/

            //default route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
