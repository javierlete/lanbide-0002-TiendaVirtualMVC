using Entidades;
using System;
using System.Data.Entity;
using System.Linq;
using static Entidades.Carrito;

namespace Dal
{
    public class MF0968Context : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'MF0968Context' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'Dal.MF0968Context' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'MF0968Context'  en el archivo de configuración de la aplicación.
        public MF0968Context()
            : base(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=MF0968Test;Integrated Security=True;Pooling=False")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Carrito> Carritos { get; set; }
        public virtual DbSet<Detalle> Detalles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().HasIndex(u => u.Email).IsUnique();
        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}