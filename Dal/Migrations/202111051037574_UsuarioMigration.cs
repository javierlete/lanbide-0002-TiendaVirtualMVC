namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuarioMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 64),
                        Nombre = c.String(maxLength: 50),
                        Rol = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Usuarios", new[] { "Email" });
            DropTable("dbo.Usuarios");
        }
    }
}
