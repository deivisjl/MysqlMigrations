namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SprintV5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pensum",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Activo = c.Int(nullable: false),
                        GradoCarreraId = c.Int(nullable: false),
                        CicloEscolarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CicloEscolar", t => t.CicloEscolarId, cascadeDelete: true)
                .ForeignKey("dbo.GradoCarrera", t => t.GradoCarreraId, cascadeDelete: true)
                .Index(t => t.GradoCarreraId)
                .Index(t => t.CicloEscolarId);
            
            CreateTable(
                "dbo.PensumCurso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PensumId = c.Int(nullable: false),
                        CursoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Curso", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.Pensum", t => t.PensumId, cascadeDelete: true)
                .Index(t => t.PensumId)
                .Index(t => t.CursoId);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Inscrito", "Repitente", c => c.Int(nullable: false));
            AddColumn("dbo.Inscrito", "Estado", c => c.Int(nullable: false));
            AddColumn("dbo.Inscrito", "UsuarioId", c => c.Int(nullable: false));
            AddColumn("dbo.CicloEscolar", "Activo", c => c.Int(nullable: false));
            AddColumn("dbo.Usuario", "Estado", c => c.Int(nullable: false));
            CreateIndex("dbo.Inscrito", "UsuarioId");
            AddForeignKey("dbo.Inscrito", "UsuarioId", "dbo.Usuario", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscrito", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.PensumCurso", "PensumId", "dbo.Pensum");
            DropForeignKey("dbo.PensumCurso", "CursoId", "dbo.Curso");
            DropForeignKey("dbo.Pensum", "GradoCarreraId", "dbo.GradoCarrera");
            DropForeignKey("dbo.Pensum", "CicloEscolarId", "dbo.CicloEscolar");
            DropIndex("dbo.PensumCurso", new[] { "CursoId" });
            DropIndex("dbo.PensumCurso", new[] { "PensumId" });
            DropIndex("dbo.Pensum", new[] { "CicloEscolarId" });
            DropIndex("dbo.Pensum", new[] { "GradoCarreraId" });
            DropIndex("dbo.Inscrito", new[] { "UsuarioId" });
            DropColumn("dbo.Usuario", "Estado");
            DropColumn("dbo.CicloEscolar", "Activo");
            DropColumn("dbo.Inscrito", "UsuarioId");
            DropColumn("dbo.Inscrito", "Estado");
            DropColumn("dbo.Inscrito", "Repitente");
            DropTable("dbo.Curso");
            DropTable("dbo.PensumCurso");
            DropTable("dbo.Pensum");
        }
    }
}
