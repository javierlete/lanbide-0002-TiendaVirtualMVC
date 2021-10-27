namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductoMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nombre = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Productos");
        }
    }
}
