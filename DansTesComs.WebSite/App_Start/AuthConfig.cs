// DansTesComs -> DansTesComs.WebSite ->AuthConfig.cs
// fichier créée le 06/07/2014 a 16:21
// par lucas zientek ( lucas )

using System;
using DansTesComs.WebSite.Filters;
using WebMatrix.WebData;

namespace DansTesComs.WebSite
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // Pour permettre aux utilisateurs de ce site de se connecter à l’aide de leur compte à partir d’autres sites tels que Microsoft, Facebook et Twitter,
            // vous devez mettre à jour ce site. Pour plus d’informations, consultez la page http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "",
            //    appSecret: "");

            //OAuthWebSecurity.RegisterGoogleClient();
            try
            {

                WebSecurity.InitializeDatabaseConnection("DansTesComsSqlServeur", "Users", "id", "Pseudo", true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Impossible d'initialiser la base de données ASP.NET Simple Membership. Pour plus d'informations, consultez la page http://go.microsoft.com/fwlink/?LinkId=256588", ex);
            }
        }
    }
}