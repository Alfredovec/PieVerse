using System.Web;
using System.Web.Mvc;

namespace PieVerse.Web.Attributes
{
    public class PieverseAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool auth = HttpContext.Current.User.Identity.IsAuthenticated;
            if (!auth)
                base.OnAuthorization(filterContext);
        }
    }
}