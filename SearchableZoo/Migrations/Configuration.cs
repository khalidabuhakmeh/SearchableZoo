namespace SearchableZoo.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SearchableZoo.Models.ZooDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SearchableZoo.Models.ZooDbContext context)
        {
        }
    }
}
