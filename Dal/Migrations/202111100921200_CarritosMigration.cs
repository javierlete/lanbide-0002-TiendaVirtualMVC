namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarritosMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carritos",
                c => new
                    {
                        Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Detalles",
                c => new
                    {
                        CarritoId = c.Long(nullable: false),
                        ProductoId = c.Long(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CarritoId, t.ProductoId })
                .ForeignKey("dbo.Carritos", t => t.CarritoId, cascadeDelete: true)
                .ForeignKey("dbo.Productos", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.CarritoId)
                .Index(t => t.ProductoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carritos", "Id", "dbo.Usuarios");
            DropForeignKey("dbo.Detalles", "ProductoId", "dbo.Productos");
            DropForeignKey("dbo.Detalles", "CarritoId", "dbo.Carritos");
            DropIndex("dbo.Detalles", new[] { "ProductoId" });
            DropIndex("dbo.Detalles", new[] { "CarritoId" });
            DropIndex("dbo.Carritos", new[] { "Id" });
            DropTable("dbo.Detalles");
            DropTable("dbo.Carritos");
        }
    }
}
