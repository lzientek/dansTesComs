// DansTesComs -> DansTesComs.WebSite ->RouteConfig.cs
// fichier créée le 06/07/2014 a 16:21
// par lucas zientek ( lucas )

using System.Web.Mvc;
using System.Web.Routing;

namespace DansTesComs.WebSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}