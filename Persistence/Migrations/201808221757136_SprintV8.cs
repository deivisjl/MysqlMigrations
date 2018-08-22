namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SprintV8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pago",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InscritoId = c.Int(nullable: false),
                        MesId = c.Int(nullable: false),
                        CicloEscolarId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        Monto = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CicloEscolar", t => t.CicloEscolarId, cascadeDelete: true)
                .ForeignKey("dbo.Inscrito", t => t.InscritoId, cascadeDelete: true)
                .ForeignKey("dbo.Mes", t => t.MesId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.InscritoId)
                .Index(t => t.MesId)
                .Index(t => t.CicloEscolarId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pago", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Pago", "MesId", "dbo.Mes");
            DropForeignKey("dbo.Pago", "InscritoId", "dbo.Inscrito");
            DropForeignKey("dbo.Pago", "CicloEscolarId", "dbo.CicloEscolar");
            DropIndex("dbo.Pago", new[] { "UsuarioId" });
            DropIndex("dbo.Pago", new[] { "CicloEscolarId" });
            DropIndex("dbo.Pago", new[] { "MesId" });
            DropIndex("dbo.Pago", new[] { "InscritoId" });
            DropTable("dbo.Pago");
            DropTable("dbo.Mes");
        }
    }
}
