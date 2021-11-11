using Dal;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Carrito;

namespace Bll
{
    public static class CarritoBll
    {
        private readonly static IDaoCarrito dao = FabricaDaos.ObtenerDaoCarrito(Tipos.Entity);
        public static Carrito Alta(Usuario usuario)
        {
            return dao.Insertar(new Carrito() { Usuario = usuario });
        }

        public static void Baja(Usuario usuario)
        {
            dao.Borrar(usuario.Id.Value);
        }

        public static void InsertarProducto(long carritoId, long productoId, int cantidad = 1)
        {
            Detalle detalle = new Detalle() { CarritoId = carritoId, ProductoId = productoId, Cantidad = cantidad };
            dao.InsertarDetalle(detalle);
        }

        public static void ModificarProducto(long carritoId, long productoId, int cantidad = 1)
        {
            Detalle detalle = new Detalle() { CarritoId = carritoId, ProductoId = productoId, Cantidad = cantidad };
            dao.ModificarDetalle(detalle);
        }

        public static void BorrarDetalle(long carritoId, long productoId)
        {
            dao.BorrarDetalle(carritoId, productoId);
        }
    }
}
