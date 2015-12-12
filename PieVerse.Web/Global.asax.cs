using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using PieVerse.Web.App_Start;
using WebMatrix.WebData;

namespace PieVerse.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            MapperConfig.RegisterMaps();
            WebSecurity.InitializeDatabaseConnection("PieverseContext", "UserProfile", "UserId", "UserName", true);
            if (!Roles.RoleExists("User"))
                Roles.CreateRole("User");
            if (!Roles.RoleExists("Admin"))
                Roles.CreateRole("Admin");
            if (!WebSecurity.UserExists("Admin"))
            {
                WebSecurity.CreateUserAndAccount("Admin", "Admin");
                Roles.AddUserToRole("Admin", "Admin");
            }
            if (!WebSecurity.UserExists("User"))
            {
                WebSecurity.CreateUserAndAccount("User", "User");
                Roles.AddUserToRole("User", "User");
            }
        }
    }
}