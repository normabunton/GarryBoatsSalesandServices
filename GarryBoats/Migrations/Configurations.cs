using System.Data.Entity.Migrations;

namespace GarryBoats.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<GarryBoats.Models.ProductDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(GarryBoats.Models.ProductDbContext context)
        {
            base.Seed(context);
        }
    }
   
}