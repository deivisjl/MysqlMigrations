namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SprintV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carrera",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        NivelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nivel", t => t.NivelId, cascadeDelete: true)
                .Index(t => t.NivelId);
            
            CreateTable(
                "dbo.Nivel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Apellidos = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Dpi = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        Telefono = c.Int(nullable: false),
                        Direccion = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Email = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Password = c.String(nullable: false, maxLength: 150, storeType: "nvarchar"),
                        RolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rol", t => t.RolId, cascadeDelete: true)
                .Index(t => t.RolId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "RolId", "dbo.Rol");
            DropForeignKey("dbo.Carrera", "NivelId", "dbo.Nivel");
            DropIndex("dbo.Usuario", new[] { "RolId" });
            DropIndex("dbo.Carrera", new[] { "NivelId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Rol");
            DropTable("dbo.Nivel");
            DropTable("dbo.Carrera");
        }
    }
}
