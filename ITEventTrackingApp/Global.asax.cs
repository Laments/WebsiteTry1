using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ITEventTrackingApp.Models.DatabaseModel;
using System.Data.Entity;
using ITEventTrackingApp.Models.Database;

namespace ITEventTrackingApp
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Force initialize DB at startup - useful mostly since it enables a minimum viable base (DB with dummy data)
            DatabaseTables dbContext = new DatabaseTables();
            //note: using the below initializer since without it dbContext is a null object without it
            Database.SetInitializer<DatabaseTables>(new CreateDatabaseIfNotExists<DatabaseTables>());
            new DatabaseBootstrapper(dbContext).Configure();
        }
    }
}
