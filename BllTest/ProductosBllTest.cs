using Dal;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace Bll
{
    [TestClass]
    public class ProductosBllTest
    {
        private static readonly Producto producto1 = new Producto() { Id = 1L, Nombre = "Monitor", Precio = 123.45m };
        private static readonly Producto producto2 = new Producto() { Id = 2L, Nombre = "Patatas", Precio = 12.34m, FechaCaducidad = new DateTime(2000, 1, 2), Foto = "dos.jpg" };
        private static readonly List<Producto> productos = new List<Producto>() { producto1, producto2 };

        private DbConnection ObtenerConexion()
        {
            return new SqlConnection(System.Configuration.ConfigurationManager.
                ConnectionStrings["MF0968Context"].ConnectionString);
        }

        [TestInitialize]
        public void PreTest()
        {
            using (DbConnection con = ObtenerConexion())
            {
                con.Open();

                DbCommand com = con.CreateCommand();

                com.CommandText = "TRUNCATE TABLE Productos";
                com.ExecuteNonQuery();

                com.CommandText = "INSERT INTO Productos (Nombre, Precio, FechaCaducidad) VALUES (@Nombre, @Precio, @FechaCaducidad)";

                DbParameter parNombre = com.CreateParameter();
                parNombre.ParameterName = "Nombre";
                parNombre.DbType = System.Data.DbType.String;
                com.Parameters.Add(parNombre);

                DbParameter parPrecio = com.CreateParameter();
                parPrecio.ParameterName = "Precio";
                parPrecio.DbType = System.Data.DbType.Decimal;
                com.Parameters.Add(parPrecio);

                DbParameter parFechaCaducidad = com.CreateParameter();
                parFechaCaducidad.ParameterName = "FechaCaducidad";
                parFechaCaducidad.DbType = System.Data.DbType.Date;
                com.Parameters.Add(parFechaCaducidad);

                foreach (Producto producto in productos)
                {
                    parNombre.Value = producto.Nombre;
                    parPrecio.Value = producto.Precio;

                    if (producto.FechaCaducidad.HasValue)
                    {
                        parFechaCaducidad.Value = producto.FechaCaducidad;
                    }
                    else
                    {
                        parFechaCaducidad.Value = DBNull.Value;
                    }

                    com.ExecuteNonQuery();
                }
            }
        }

        [TestMethod]
        public void Consultar()
        {
            List<Producto> productos = ProductosBll.Consultar(new Usuario() { Rol = "ADMIN" }) as List<Producto>;

            Assert.IsNotNull(productos);

            Assert.AreEqual(2, productos.Count);

            Assert.AreEqual(producto1, productos[0]);
            Assert.AreEqual(producto2, productos[1]);

            Assert.ThrowsException<UnauthorizedAccessException>(() => ProductosBll.Consultar(new Usuario() { Rol = "USER" }));
        }
    }
}
