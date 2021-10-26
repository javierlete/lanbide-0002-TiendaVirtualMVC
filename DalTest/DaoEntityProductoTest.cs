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
        private static readonly IDaoProducto dao = new DaoEntityProducto();

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

                com.CommandText = "INSERT INTO Productos (Nombre, Precio) VALUES ('Monitor', 123.45)";
                com.ExecuteNonQuery();

                com.CommandText = "INSERT INTO Productos (Nombre, Precio) VALUES ('Ratón', 12.34)";
                com.ExecuteNonQuery();
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

            Assert.AreEqual(new Producto() { Id = 1L, Nombre = "Monitor", Precio = 123.45m }, productos[0]);
            Assert.AreEqual(new Producto() { Id = 2L, Nombre = "Ratón", Precio = 12.34m }, productos[1]);
        }

        [TestMethod]
        public void ObtenerPorId()
        {
            Producto producto = dao.ObtenerPorId(1L);

            Assert.IsNotNull(producto);

            Assert.AreEqual(new Producto() { Id = 1L, Nombre = "Monitor", Precio = 123.45m }, producto);

            producto = dao.ObtenerPorId(10L);

            Assert.IsNull(producto);
        }

        [TestMethod]
        public void Insertar()
        {
            Producto nuevo = new Producto() { Nombre = "Nuevo", Precio = 43.21m };
            dao.Insertar(nuevo);

            Assert.AreEqual(3L, nuevo.Id);

            using(DbConnection con = ObtenerConexion())
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

            using(DbConnection con = ObtenerConexion())
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
