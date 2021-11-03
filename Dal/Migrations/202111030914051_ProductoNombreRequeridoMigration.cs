namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductoNombreRequeridoMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productos", "Nombre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productos", "Nombre", c => c.String());
        }
    }
}
