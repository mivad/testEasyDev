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
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(API.Context.EasyDevContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var candidatos = new List<Candidato>
            {
                new Candidato{id=1,nomeCompleto="Bart Simpson", email="bart@email.com", dtHoraCadastro = DateTime.Now},
                new Candidato{id=2,nomeCompleto="Lisa Simpson", email="lisa@email.com", dtHoraCadastro = DateTime.Now}
            };

            candidatos.ForEach(s => context.Candidatos.AddOrUpdate(s));
            context.SaveChanges();

            var conhecimentos = new List<Conhecimento>
            {
                new Conhecimento{id=1, descricao = "Ionic", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=2, descricao = "Android", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=3, descricao = "IOS", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=4, descricao = "HTML", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=5, descricao = "CSS", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=6, descricao = "Bootstrap", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=7, descricao = "Jquery", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=8, descricao = "AngularJs", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=9, descricao = "Java", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=10, descricao = "Asp.Net MVC", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=11, descricao = "Asp.Net WebForm", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=12, descricao = "C", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=13, descricao = "C#", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=14, descricao = "Cake", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=15, descricao = "Django", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=16, descricao = "Majento", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=17, descricao = "PHP", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=18, descricao = "Vue", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=19, descricao = "Wordpress", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=20, descricao = "Phyton", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=21, descricao = "Ruby", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=22, descricao = "My SQL Server", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=23, descricao = "My SQL", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=24, descricao = "Salesforce", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=25, descricao = "Photoshop", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=26, descricao = "Illustrator", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=27, descricao = "SEO", dtHoraCadastro = DateTime.Now},
                new Conhecimento{id=28, descricao = "Laravel", dtHoraCadastro = DateTime.Now},
            };

            conhecimentos.ForEach(s => context.Conhecimentos.AddOrUpdate(s));
            context.SaveChanges();


            var candidatoConhecimentos = new List<CandidatoConhecimento>
            {
                new CandidatoConhecimento{id=1,candidatoId = 1, conhecimentoId = 1, valor = 5,  dtHoraCadastro = DateTime.Now},
                new CandidatoConhecimento{id=2,candidatoId = 1, conhecimentoId = 2, valor = 5,  dtHoraCadastro = DateTime.Now},
                new CandidatoConhecimento{id=3,candidatoId = 1, conhecimentoId = 3, valor = 0,  dtHoraCadastro = DateTime.Now},
                new CandidatoConhecimento{id=4,candidatoId = 1, conhecimentoId = 4, valor = 3,  dtHoraCadastro = DateTime.Now},
                new CandidatoConhecimento{id=5,candidatoId = 1, conhecimentoId = 5, valor = 2,  dtHoraCadastro = DateTime.Now},

                new CandidatoConhecimento{id=6,candidatoId = 2, conhecimentoId = 6, valor = 1,  dtHoraCadastro = DateTime.Now},
                new CandidatoConhecimento{id=7,candidatoId = 2, conhecimentoId = 7, valor = 2,  dtHoraCadastro = DateTime.Now},
                new CandidatoConhecimento{id=8,candidatoId = 2, conhecimentoId = 8, valor = 4,  dtHoraCadastro = DateTime.Now},
                new CandidatoConhecimento{id=9,candidatoId = 2, conhecimentoId = 9, valor = 4,  dtHoraCadastro = DateTime.Now},
                new CandidatoConhecimento{id=10,candidatoId = 2, conhecimentoId = 10, valor = 5,  dtHoraCadastro = DateTime.Now},
            };



            var candidatosComConhecimentos = new List<Candidato>
            {
                new Candidato
                {
                            id = 3,
                            nomeCompleto ="Hormer Simpson",
                            email ="hormer@email.com",
                            dtHoraCadastro = DateTime.Now,
                            conhecimentos = new List<CandidatoConhecimento>
                            {
                                new CandidatoConhecimento{conhecimentoId=11, valor = 4,  dtHoraCadastro = DateTime.Now},
                                new CandidatoConhecimento{conhecimentoId=14, valor = 4,  dtHoraCadastro = DateTime.Now}
                            }
                },
                new Candidato
                {
                            id = 4,
                            nomeCompleto ="Marge Simpson",
                            email ="marge@email.com",
                            dtHoraCadastro = DateTime.Now,
                            conhecimentos = new List<CandidatoConhecimento>
                            {
                                new CandidatoConhecimento{conhecimentoId=1, valor = 2,  dtHoraCadastro = DateTime.Now},
                                new CandidatoConhecimento{conhecimentoId=2, valor = 0,  dtHoraCadastro = DateTime.Now}
                            }
                }
            };

            candidatosComConhecimentos.ForEach(s => context.Candidatos.AddOrUpdate(s));
            context.SaveChanges();
        }
    }
}
