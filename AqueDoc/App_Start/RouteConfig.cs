using System.Web.Mvc;
using System.Web.Routing;

namespace AqueDoc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Here go the routes that you still want to be able to hit
            routes.MapRoute(
                name: "IAmARouteThatYouStillWantToHit",
                url: "AqueDoc/",
                defaults: new { controller = "Home", action = "Index" }
            );

            // Everything else will hit Home/Index which serves up the root angular app page
            routes.MapRoute(
                name: "Default",
                url: "{*anything}", // THIS IS THE MAGIC!!!!
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}