using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace Dal
{
    [TestClass]
    public class DaoEntityProductoTest
    {
        private static readonly IDaoProducto dao = FabricaDaos.ObtenerDaoProducto(Tipos.Entity);
        private static readonly Producto producto1 = new Producto() { Id = 1L, Nombre = "Monitor", Precio = 123.45m };
        private static readonly Producto producto2 = new Producto() { Id = 2L, Nombre = "Patatas", Precio = 12.34m, FechaCaducidad = new DateTime(2000, 1, 2) };
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

        //[TestCleanup]
        //public void PostTest()
        //{
        //    using (DbConnection con = ObtenerConexion())
        //    {
        //        con.Open();

        //        DbCommand com = con.CreateCommand();
        //        com.CommandText = "TRUNCATE TABLE Productos";

        //        com.ExecuteNonQuery();
        //    }
        //}

        [TestMethod]
        public void ObtenerTodos()
        {
            List<Producto> productos = dao.ObtenerTodos() as List<Producto>;

            Assert.IsNotNull(productos);

            Assert.AreEqual(2, productos.Count);

            Assert.AreEqual(producto1, productos[0]);
            Assert.AreEqual(producto2, productos[1]);
        }

        [TestMethod]
        public void ObtenerPorId()
        {
            Producto producto = dao.ObtenerPorId(1L);

            Assert.IsNotNull(producto);

            Assert.AreEqual(producto1, producto);

            producto = dao.ObtenerPorId(10L);

            Assert.IsNull(producto);

            producto = dao.ObtenerPorId(2L);

            Assert.IsNotNull(producto);

            Assert.AreEqual(producto2, producto);
        }

        [TestMethod]
        public void Insertar()
        {
            Producto nuevo = new Producto() { Nombre = "Nuevo", Precio = 43.21m };
            dao.Insertar(nuevo);

            Assert.AreEqual(3L, nuevo.Id);

            using (DbConnection con = ObtenerConexion())
            {
                con.Open();

                DbCommand com = con.CreateCommand();
                com.CommandText = "SELECT * FROM Productos WHERE Id = 3";

                DbDataReader dr = com.ExecuteReader();

                Assert.IsTrue(dr.Read());

                Assert.AreEqual("Nuevo", dr["Nombre"]);
                Assert.AreEqual(43.21m, dr["Precio"]);
            }
        }

        [TestMethod]
        public void Modificar()
        {
            Producto modificado = new Producto() { Id = 2L, Nombre = "Modificar", Precio = 43.21m };
            dao.Modificar(modificado);

            using (DbConnection con = ObtenerConexion())
            {
                con.Open();

                DbCommand com = con.CreateCommand();
                com.CommandText = "SELECT * FROM Productos WHERE Id = 2";

                DbDataReader dr = com.ExecuteReader();

                Assert.IsTrue(dr.Read());

                Assert.AreEqual("Modificar", dr["Nombre"]);
                Assert.AreEqual(43.21m, dr["Precio"]);
            }
        }

        [TestMethod]
        public void Borrar()
        {
            dao.Borrar(1L);

            using (DbConnection con = ObtenerConexion())
            {
                con.Open();

                DbCommand com = con.CreateCommand();
                com.CommandText = "SELECT * FROM Productos WHERE Id = 1";

                DbDataReader dr = com.ExecuteReader();

                Assert.IsFalse(dr.Read());
            }
        }
    }
}
