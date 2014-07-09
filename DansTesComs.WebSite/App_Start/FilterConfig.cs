// DansTesComs -> DansTesComs.WebSite ->FilterConfig.cs
// fichier créée le 06/07/2014 a 16:21
// par lucas zientek ( lucas )

using System.Web.Mvc;

namespace DansTesComs.WebSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}