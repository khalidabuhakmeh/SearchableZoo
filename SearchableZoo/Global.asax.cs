using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using MvcFlash.Core;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;
using SearchableZoo.Migrations;
using SearchableZoo.Models;

namespace SearchableZoo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        public static readonly IDocumentStore DocumentStore = new DocumentStore()
        {
            ConnectionStringName = "RavenDB"
        }.Initialize();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            IndexCreation.CreateIndexes(typeof(MvcApplication).Assembly, DocumentStore);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ZooDbContext, Configuration>());
            using (var db = new ZooDbContext())
            {
                db.Database.Initialize(true);
            }
        }
    }
}