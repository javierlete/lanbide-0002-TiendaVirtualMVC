namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductoFotoMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productos", "Foto", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productos", "Foto");
        }
    }
}
