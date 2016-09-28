using HelloWeb.DependencyInversion;
using StructureMap;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HelloWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static Container DependencyResolver;

        static MvcApplication()
        {
            DependencyResolver = new Container(new RuntimeRegistry());
        }


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
