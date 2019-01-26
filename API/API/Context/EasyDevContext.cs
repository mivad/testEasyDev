using API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;


namespace API.Context
{
    public class EasyDevContext : DbContext
    {
        public EasyDevContext()
           : base("name=dbeasydev")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Conhecimento> Conhecimentos { get; set; }
        public DbSet<CandidatoConhecimento> CandidatoConhecimentos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Candidato>()
                .ToTable("Candidato");
        }
    }
}