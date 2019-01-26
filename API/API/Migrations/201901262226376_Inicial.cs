namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CandidatoConhecimento",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        valor = c.Int(nullable: false),
                        candidatoId = c.Int(nullable: false),
                        conhecimentoId = c.Int(nullable: false),
                        dtHoraCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Candidato", t => t.candidatoId, cascadeDelete: true)
                .ForeignKey("dbo.Conhecimento", t => t.conhecimentoId, cascadeDelete: true)
                .Index(t => new { t.candidatoId, t.conhecimentoId }, unique: true, name: "ORDER_CC");
            
            CreateTable(
                "dbo.Candidato",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nomeCompleto = c.String(nullable: false),
                        email = c.String(nullable: false, maxLength: 220, unicode: false),
                        skype = c.String(),
                        phone = c.String(),
                        linkedIn = c.String(),
                        cidade = c.String(),
                        estado = c.String(),
                        portfolio = c.String(),
                        disponibilidadeTrabalho = c.String(),
                        melhorHorarioTrabalho = c.String(),
                        pretensaoSalario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dtHoraCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.email, unique: true);
            
            CreateTable(
                "dbo.Conhecimento",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        descricao = c.String(nullable: false, maxLength: 120, unicode: false),
                        dtHoraCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.descricao, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CandidatoConhecimento", "conhecimentoId", "dbo.Conhecimento");
            DropForeignKey("dbo.CandidatoConhecimento", "candidatoId", "dbo.Candidato");
            DropIndex("dbo.Conhecimento", new[] { "descricao" });
            DropIndex("dbo.Candidato", new[] { "email" });
            DropIndex("dbo.CandidatoConhecimento", "ORDER_CC");
            DropTable("dbo.Conhecimento");
            DropTable("dbo.Candidato");
            DropTable("dbo.CandidatoConhecimento");
        }
    }
}
