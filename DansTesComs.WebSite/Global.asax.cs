// DansTesComs -> DansTesComs.WebSite ->Global.asax.cs
// fichier créée le 06/07/2014 a 16:21
// par lucas zientek ( lucas )

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DansTesComs.Core.Models;
using DansTesComs.WebSite.Filters;
using Microsoft.Ajax.Utilities;
using WebMatrix.WebData;

namespace DansTesComs.WebSite
{
    // Remarque : pour obtenir des instructions sur l'activation du mode classique IIS6 ou IIS7, 
    // visitez http://go.microsoft.com/?LinkId=9394801

    [InitializeSimpleMembershipAttribute]
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }


        protected void Application_AuthenticateRequest(object sender, EventArgs args)
        {

            if (Context.User != null)
            {
                IEnumerable<Role> roles = new DansTesComsEntities().Users.Find(WebSecurity.CurrentUserId).Roles;


                string[] rolesArray = new string[roles.Count()];
                for (int i = 0; i < roles.Count(); i++)
                {
                    rolesArray[i] = roles.ElementAt(i).RoleName;
                }

                GenericPrincipal gp = new GenericPrincipal(Context.User.Identity, rolesArray);
                Context.User = gp;
            }
        }
    }

}