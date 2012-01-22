using System.Data.Entity.Migrations;
using System.Web.Mvc;
using System.Web.Routing;
using Elmah.Contrib.Mvc;
using NuGetGallery.Migrations;

[assembly: WebActivator.PreApplicationStartMethod(typeof(NuGetGallery.Bootstrapper), "Start")]
namespace NuGetGallery
{
    using System.Linq;
    using MvcOverrides;

    public static class Bootstrapper
    {
        public static void Start()
        {
            UpdateDatabase();
            Routes.RegisterRoutes(RouteTable.Routes);

            var routes = RouteTable.Routes.OfType<Route>().Where(x => x.RouteHandler is MvcRouteHandler);
            foreach (var route in routes)
            {
                route.RouteHandler = new CustomMvcRouteHandler();
            }

            DynamicDataEFCodeFirst.Registration.Register(RouteTable.Routes);

            // TODO: move profile bootstrapping and container bootstrapping to here
            GlobalFilters.Filters.Add(new ElmahHandleErrorAttribute());
        }

        private static void UpdateDatabase()
        {
            var dbMigrator = new DbMigrator(new Settings());
            dbMigrator.Update();
        }
    }
}