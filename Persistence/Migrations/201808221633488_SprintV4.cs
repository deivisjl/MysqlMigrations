namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SprintV4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumno",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrimerNombre = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        SegundoNombre = c.String(maxLength: 50, storeType: "nvarchar"),
                        TercerNombre = c.String(maxLength: 50, storeType: "nvarchar"),
                        PrimerApellido = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        SegundoApellido = c.String(maxLength: 50, storeType: "nvarchar"),
                        Genero = c.String(nullable: false, maxLength: 5, storeType: "nvarchar"),
                        Dpi = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                        Telefono = c.String(maxLength: 20, storeType: "nvarchar"),
                        Direccion = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inscrito",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        AlumnoId = c.Int(nullable: false),
                        SalonId = c.Int(nullable: false),
                        CicloEscolarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Alumno", t => t.AlumnoId, cascadeDelete: true)
                .ForeignKey("dbo.CicloEscolar", t => t.CicloEscolarId, cascadeDelete: true)
                .ForeignKey("dbo.Salon", t => t.SalonId, cascadeDelete: true)
                .Index(t => t.AlumnoId)
                .Index(t => t.SalonId)
                .Index(t => t.CicloEscolarId);
            
            CreateTable(
                "dbo.CicloEscolar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscrito", "SalonId", "dbo.Salon");
            DropForeignKey("dbo.Inscrito", "CicloEscolarId", "dbo.CicloEscolar");
            DropForeignKey("dbo.Inscrito", "AlumnoId", "dbo.Alumno");
            DropIndex("dbo.Inscrito", new[] { "CicloEscolarId" });
            DropIndex("dbo.Inscrito", new[] { "SalonId" });
            DropIndex("dbo.Inscrito", new[] { "AlumnoId" });
            DropTable("dbo.CicloEscolar");
            DropTable("dbo.Inscrito");
            DropTable("dbo.Alumno");
        }
    }
}
