using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static Entidades.Carrito;

namespace Dal
{
    [TestClass]
    public class DaoEntityCarritoTest
    {
        private readonly static IDaoUsuario daoUsuario = FabricaDaos.ObtenerDaoUsuario(Tipos.Entity);
        private readonly static IDaoCarrito dao = FabricaDaos.ObtenerDaoCarrito(Tipos.Entity);
        private readonly static IDaoProducto daoProducto = FabricaDaos.ObtenerDaoProducto(Tipos.Entity);

        [TestMethod]
        public void Insertar()
        {
            Usuario usuario = daoUsuario.ObtenerPorEmail("pepe@email.net");

            Carrito carrito = new Carrito
            {
                Usuario = usuario
            };

            dao.Insertar(carrito);
        }

        [TestMethod]
        public void InsertarDetalle()
        {
            Detalle detalle = new Detalle()
            {
                CarritoId = 2L,
                ProductoId = 3L,
                Cantidad = 4
            };
            
            dao.InsertarDetalle(detalle);
        }

        [TestMethod]
        public void ObtenerPorId()
        {
            Carrito carrito = dao.ObtenerPorId(2L);

            Assert.AreEqual("pepe@email.net", carrito.Usuario.Email);

            IEnumerator<Detalle> detalles= carrito.Detalles.GetEnumerator();

            detalles.MoveNext();

            Assert.AreEqual("Prueba Seed", detalles.Current.Producto.Nombre);
            Assert.AreEqual(4, detalles.Current.Cantidad);
        }
    }
}
