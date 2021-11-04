using Dal;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class ProductosBll
    {
        private static readonly IDaoProducto dao = FabricaDaos.ObtenerDaoProducto(Tipos.Entity);
        public static IEnumerable<Producto> Consultar()
        {
            return dao.ObtenerTodos();
        }

        public static Producto BuscarPorId(long? id)
        {
            return dao.ObtenerPorId(id.Value);
        }

        public static void Guardar(Producto producto)
        {
            dao.Insertar(producto);
        }

        public static void Modificar(Producto producto)
        {
            dao.Modificar(producto);
        }

        public static void Borrar(long id)
        {
            dao.Borrar(id);
        }
    }
}
