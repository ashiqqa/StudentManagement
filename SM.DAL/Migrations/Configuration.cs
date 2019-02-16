namespace SM.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SM.DAL.DbContextSMS>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SM.DAL.DbContextSMS";
        }

        protected override void Seed(SM.DAL.DbContextSMS context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
