namespace Data.Migrations
{
    using Data.Contexto;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DbContexto>
    {
        public Configuration()
        {
            //Ativa as Migrations Automáticas
            AutomaticMigrationsEnabled = true;

            //Permite que haja perda de dados quando ocorrer migrations automáticas;
            AutomaticMigrationDataLossAllowed = true;

            ContextKey = "DbContexto";
        }

        protected override void Seed(DbContexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
