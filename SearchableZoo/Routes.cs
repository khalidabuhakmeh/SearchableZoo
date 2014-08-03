using System.Web.Routing;
using RestfulRouting;
using SearchableZoo.Controllers;

[assembly: WebActivator.PreApplicationStartMethod(typeof(SearchableZoo.Routes), "Start")]

namespace SearchableZoo
{
    public class Routes : RouteSet
    {
        public override void Map(IMapper map)
        {
            map.DebugRoute("routedebug");
            map.Root<KeepersController>(x => x.Index(null));
            map.Resources<KeepersController>();
        }

        public static void Start()
        {
            var routes = RouteTable.Routes;
            routes.MapRoutes<Routes>();
        }
    }
}