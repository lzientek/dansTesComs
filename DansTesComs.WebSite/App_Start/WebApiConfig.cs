// DansTesComs -> DansTesComs.WebSite ->WebApiConfig.cs
// fichier créée le 08/07/2014 a 20:40
// par lucas zientek ( lucas )

using System.Web.Http;

namespace DansTesComs.WebSite
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional}
                );

            // Supprimez les commentaires de la ligne de code suivante pour activer la prise en charge des requêtes pour les actions ayant un type de retour IQueryable ou IQueryable<T>.
            // Pour éviter le traitement de requêtes inattendues ou malveillantes, utilisez les paramètres de validation définis sur QueryableAttribute pour valider les requêtes entrantes.
            // Pour plus d’informations, visitez http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();
        }
    }
}