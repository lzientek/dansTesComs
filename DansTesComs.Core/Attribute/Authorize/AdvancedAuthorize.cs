using System.Web.Mvc;

namespace DansTesComs.Core.Attribute.Authorize
{
    class AdvancedAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}
