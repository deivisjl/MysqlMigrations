namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SprintV2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GradoCarrera",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GradoId = c.Int(nullable: false),
                        CarreraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carrera", t => t.CarreraId, cascadeDelete: true)
                .ForeignKey("dbo.Grado", t => t.GradoId, cascadeDelete: true)
                .Index(t => t.GradoId)
                .Index(t => t.CarreraId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GradoCarrera", "GradoId", "dbo.Grado");
            DropForeignKey("dbo.GradoCarrera", "CarreraId", "dbo.Carrera");
            DropIndex("dbo.GradoCarrera", new[] { "CarreraId" });
            DropIndex("dbo.GradoCarrera", new[] { "GradoId" });
            DropTable("dbo.GradoCarrera");
            DropTable("dbo.Grado");
        }
    }
}
