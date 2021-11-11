using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using static Entidades.Carrito;

namespace Dal
{
    [TestClass]
    public class DaoEntityCarritoTest
    {
        private readonly static IDaoUsuario daoUsuario = FabricaDaos.ObtenerDaoUsuario(Tipos.Entity);
        private readonly static IDaoCarrito dao = FabricaDaos.ObtenerDaoCarrito(Tipos.Entity);
        private readonly static IDaoProducto daoProducto = FabricaDaos.ObtenerDaoProducto(Tipos.Entity);

        private DbConnection ObtenerConexion()
        {
            return new SqlConnection(System.Configuration.ConfigurationManager.
                ConnectionStrings["MF0968Context"].ConnectionString);
        }

        [TestMethod]
        public void Insertar()
        {
            using (DbConnection con = ObtenerConexion())
            {
                con.Open();

                DbCommand com = con.CreateCommand();
                com.CommandText = "SELECT MAX(Email) FROM Usuarios";

                string email = (string)com.ExecuteScalar();

                Usuario usuario = daoUsuario.ObtenerPorEmail("pepe@email.net");

                com.CommandText = "DELETE FROM Carritos WHERE Id = " + usuario.Id;
                com.ExecuteNonQuery();

                Carrito carrito = new Carrito
                {
                    Usuario = usuario
                };

                Assert.AreEqual(usuario.Id, dao.Insertar(carrito).Id);

                Assert.ThrowsException<DbUpdateException>(() => dao.Insertar(carrito));
            }
        }

        [TestMethod]
        public void InsertarDetalle()
        {
            using (DbConnection con = ObtenerConexion())
            {
                con.Open();

                DbCommand com = con.CreateCommand();
                com.CommandText = "SELECT MAX(Id) FROM Carritos";

                long id = (long)com.ExecuteScalar();

                com.CommandText = "DELETE FROM Detalles WHERE CarritoId = " + id + " AND ProductoId = 3";
                com.ExecuteNonQuery();

                Detalle detalle = new Detalle()
                {
                    CarritoId = id,
                    ProductoId = 3L,
                    Cantidad = 4
                };

                dao.InsertarDetalle(detalle);

                Assert.ThrowsException<DbUpdateException>(() => dao.InsertarDetalle(detalle));
            }
        }

        [TestMethod]
        public void ObtenerPorId()
        {
            Carrito carrito = dao.ObtenerPorId(2L);

            Assert.AreEqual("pepe@email.net", carrito.Usuario.Email);

            IEnumerator<Detalle> detalles = carrito.Detalles.GetEnumerator();

            detalles.MoveNext();

            Assert.AreEqual("Prueba Seed", detalles.Current.Producto.Nombre);
            Assert.AreEqual(4, detalles.Current.Cantidad);
        }
    }
}
