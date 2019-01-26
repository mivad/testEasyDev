namespace API.Migrations
{
    using API.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<API.Context.EasyDevContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(API.Context.EasyDevContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var candidatos = new List<Candidato>
            {
                new Candidato{id=1,nomeCompleto="Bart Simpson", email="bart@email.com"},
                new Candidato{id=2,nomeCompleto="Lisa Simpson", email="lisa@email.com"}
            };

            candidatos.ForEach(s => context.Candidatos.AddOrUpdate(s));
            context.SaveChanges();
        }
    }
}
