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

            routes.MapRoute("searchRoutePage", "SearchAll/{SearchText}/{page}",
                new { controller = "Search", action = "Index" });

            routes.MapRoute("searchRoute", "SearchAll/{SearchText}",
                new { controller = "Search", action = "Index"});

            routes.MapRoute("pageRoute", "{controller}/page/{page}",
                new { action = "Index" });

            routes.MapRoute("pageCattegorieRoute", "{controller}/{action}/page/{page}/{categorieName}",
                new { action = "Categorie" });

            routes.MapRoute("pageActionRoute", "{controller}/{action}/page/{page}",
                new { action = "Index" });

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new { controller="CommentaireExternes", action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}