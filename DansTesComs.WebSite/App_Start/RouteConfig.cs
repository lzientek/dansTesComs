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

            routes.MapRoute("pageRoute", "{controller}/page/{page}",
                new {action = "Index"});

            routes.MapRoute("categorieRoute", "{controller}/{categorieName}/page/{page}",
                new { action = "GetByCategorie" });

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new { controller = "CommentaireExternes", action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}