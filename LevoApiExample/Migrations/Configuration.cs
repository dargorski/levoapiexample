using LevoApiExample.Models;
using System.Data.Entity.Migrations;

namespace LevoApiExample.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LevoApiExample.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LevoApiExample.Models.ApplicationDbContext context)
        {
            context.Cars.AddOrUpdate(c => c.Brand,
                new Car() { Id = 1, Brand = "BMW", Model = "M3", YearOfProduction = 1992 },
                new Car() { Id = 2, Brand = "Mazda", Model = "3", YearOfProduction = 2019}
                );
        }
    }
}
