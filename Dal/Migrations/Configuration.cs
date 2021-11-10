namespace Dal.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Dal.MF0968Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Dal.MF0968Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // context.Database.ExecuteSqlCommand("TRUNCATE TABLE Productos");
            // context.Database.ExecuteSqlCommand("TRUNCATE TABLE Usuarios");

            context.Productos.AddOrUpdate(p => p.Nombre,
                new Entidades.Producto() { Nombre = "Prueba Seed", Precio = 1123.45m, FechaCaducidad = DateTime.Now, Foto = "uno.jpg" },
                new Entidades.Producto() { Nombre = "Prueba 2", Precio = 223.45m, FechaCaducidad = DateTime.Now, Foto = "dos.jpg" }
                );

            context.Usuarios.AddOrUpdate(u => u.Email,
                new Entidades.Usuario() { Email = "javier@email.net", Password = "Pa$$w0rd", Nombre = "Javier Lete", Rol = "ADMIN" },
                new Entidades.Usuario() { Email = "pepe@email.net", Password = "Pa$$w0rd", Nombre = "Pepe Pérez", Rol = "USER" }
            );
        }
    }
}
