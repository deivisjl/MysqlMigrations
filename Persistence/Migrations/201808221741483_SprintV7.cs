namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SprintV7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CursoProfesor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        SalonId = c.Int(nullable: false),
                        PensumCursoId = c.Int(nullable: false),
                        CicloEscolarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CicloEscolar", t => t.CicloEscolarId, cascadeDelete: true)
                .ForeignKey("dbo.PensumCurso", t => t.PensumCursoId, cascadeDelete: true)
                .ForeignKey("dbo.Salon", t => t.SalonId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.SalonId)
                .Index(t => t.PensumCursoId)
                .Index(t => t.CicloEscolarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CursoProfesor", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.CursoProfesor", "SalonId", "dbo.Salon");
            DropForeignKey("dbo.CursoProfesor", "PensumCursoId", "dbo.PensumCurso");
            DropForeignKey("dbo.CursoProfesor", "CicloEscolarId", "dbo.CicloEscolar");
            DropIndex("dbo.CursoProfesor", new[] { "CicloEscolarId" });
            DropIndex("dbo.CursoProfesor", new[] { "PensumCursoId" });
            DropIndex("dbo.CursoProfesor", new[] { "SalonId" });
            DropIndex("dbo.CursoProfesor", new[] { "UsuarioId" });
            DropTable("dbo.CursoProfesor");
        }
    }
}
