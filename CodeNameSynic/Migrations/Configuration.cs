namespace CodeNameSynic.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Categories.AddOrUpdate(
                new Models.Category {
                    Title = "Music",
                    Description = "Category About Music."
                },
                new Models.Category
                {
                    Title = "Gaming",
                    Description = "All things gaming."
                },
                new Models.Category
                {
                    Title = "Fitness",
                    Description = "Running, Walking, Bike ridding, etc..."
                },
                new Models.Category
                {
                    Title = "Food",
                    Description = "Events related to food go here."
                },
                new Models.Category
                {
                    Title = "Placeholder 1",
                    Description = "Placeholder Description 1"
                },
                new Models.Category
                {
                    Title = "Placeholder 2",
                    Description = "Placeholder Description 2"
                },
                new Models.Category
                {
                    Title = "Placeholder 3",
                    Description = "Placeholder Description 3"
                },
                new Models.Category
                {
                    Title = "Placeholder 4",
                    Description = "Placeholder Description 4"
                },
                new Models.Category
                {
                    Title = "Placeholder 5",
                    Description = "Placeholder Description 5"
                },
                new Models.Category
                {
                    Title = "Placeholder 6",
                    Description = "Placeholder Description 6"
                },
                new Models.Category
                {
                    Title = "Placeholder 7",
                    Description = "Placeholder Description 7"
                },
                new Models.Category
                {
                    Title = "Placeholder 8",
                    Description = "Placeholder Description 8"
                }
            );
        }
    }
}
