namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HistoryRows",
                c => new
                    {
                        MigrationId = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        ContextKey = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        Model = c.Binary(),
                        ProductVersion = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.MigrationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HistoryRows");
        }
    }
}
