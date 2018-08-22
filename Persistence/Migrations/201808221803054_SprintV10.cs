namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SprintV10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alumno", "Fecha", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Alumno", "Fecha");
        }
    }
}
