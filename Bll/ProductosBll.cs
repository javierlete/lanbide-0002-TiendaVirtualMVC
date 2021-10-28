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
    }
}
