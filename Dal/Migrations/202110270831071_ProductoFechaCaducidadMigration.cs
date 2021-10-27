namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductoFechaCaducidadMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productos", "FechaCaducidad", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productos", "FechaCaducidad");
        }
    }
}
