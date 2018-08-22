namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SprintV9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inscrito", "Fecha", c => c.DateTime(nullable: false, storeType: "date"));
            AddColumn("dbo.CursoProfesor", "Fecha", c => c.DateTime(nullable: false, storeType: "date"));
            AddColumn("dbo.Curso", "Fecha", c => c.DateTime(nullable: false, storeType: "date"));
            AddColumn("dbo.InscritoCurso", "Fecha", c => c.DateTime(nullable: false, storeType: "date"));
            AddColumn("dbo.Pensum", "Fecha", c => c.DateTime(nullable: false, storeType: "date"));
            AddColumn("dbo.Usuario", "Fecha", c => c.DateTime(nullable: false, storeType: "date"));
            AddColumn("dbo.Calificacion", "Fecha", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Calificacion", "Fecha");
            DropColumn("dbo.Usuario", "Fecha");
            DropColumn("dbo.Pensum", "Fecha");
            DropColumn("dbo.InscritoCurso", "Fecha");
            DropColumn("dbo.Curso", "Fecha");
            DropColumn("dbo.CursoProfesor", "Fecha");
            DropColumn("dbo.Inscrito", "Fecha");
        }
    }
}
