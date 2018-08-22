namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SprintV6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InscritoCurso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InscritoId = c.Int(nullable: false),
                        PensumCursoId = c.Int(nullable: false),
                        CicloEscolarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CicloEscolar", t => t.CicloEscolarId, cascadeDelete: true)
                .ForeignKey("dbo.Inscrito", t => t.InscritoId, cascadeDelete: true)
                .ForeignKey("dbo.PensumCurso", t => t.PensumCursoId, cascadeDelete: true)
                .Index(t => t.InscritoId)
                .Index(t => t.PensumCursoId)
                .Index(t => t.CicloEscolarId);
            
            CreateTable(
                "dbo.Bimestre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Calificacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valor = c.Int(nullable: false),
                        InscritoCursoId = c.Int(nullable: false),
                        BimestreId = c.Int(nullable: false),
                        CicloEscolarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bimestre", t => t.BimestreId, cascadeDelete: true)
                .ForeignKey("dbo.CicloEscolar", t => t.CicloEscolarId, cascadeDelete: true)
                .ForeignKey("dbo.InscritoCurso", t => t.InscritoCursoId, cascadeDelete: true)
                .Index(t => t.InscritoCursoId)
                .Index(t => t.BimestreId)
                .Index(t => t.CicloEscolarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calificacion", "InscritoCursoId", "dbo.InscritoCurso");
            DropForeignKey("dbo.Calificacion", "CicloEscolarId", "dbo.CicloEscolar");
            DropForeignKey("dbo.Calificacion", "BimestreId", "dbo.Bimestre");
            DropForeignKey("dbo.InscritoCurso", "PensumCursoId", "dbo.PensumCurso");
            DropForeignKey("dbo.InscritoCurso", "InscritoId", "dbo.Inscrito");
            DropForeignKey("dbo.InscritoCurso", "CicloEscolarId", "dbo.CicloEscolar");
            DropIndex("dbo.Calificacion", new[] { "CicloEscolarId" });
            DropIndex("dbo.Calificacion", new[] { "BimestreId" });
            DropIndex("dbo.Calificacion", new[] { "InscritoCursoId" });
            DropIndex("dbo.InscritoCurso", new[] { "CicloEscolarId" });
            DropIndex("dbo.InscritoCurso", new[] { "PensumCursoId" });
            DropIndex("dbo.InscritoCurso", new[] { "InscritoId" });
            DropTable("dbo.Calificacion");
            DropTable("dbo.Bimestre");
            DropTable("dbo.InscritoCurso");
        }
    }
}
