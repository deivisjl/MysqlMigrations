namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SprintV3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Salon",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeccionId = c.Int(nullable: false),
                        GradoCarreraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GradoCarrera", t => t.GradoCarreraId, cascadeDelete: true)
                .ForeignKey("dbo.Seccion", t => t.SeccionId, cascadeDelete: true)
                .Index(t => t.SeccionId)
                .Index(t => t.GradoCarreraId);
            
            CreateTable(
                "dbo.Seccion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salon", "SeccionId", "dbo.Seccion");
            DropForeignKey("dbo.Salon", "GradoCarreraId", "dbo.GradoCarrera");
            DropIndex("dbo.Salon", new[] { "GradoCarreraId" });
            DropIndex("dbo.Salon", new[] { "SeccionId" });
            DropTable("dbo.Seccion");
            DropTable("dbo.Salon");
        }
    }
}
