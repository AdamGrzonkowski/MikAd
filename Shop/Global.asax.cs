using System.Data.Entity.Migrations;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Shop.DataEntry.Migrations;

namespace Shop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var dbmigrator = new DbMigrator(new Configuration());
            dbmigrator.Update();

        }
    }
}
