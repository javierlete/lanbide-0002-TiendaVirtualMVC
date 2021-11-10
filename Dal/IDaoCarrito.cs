using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Carrito;

namespace Dal
{
    public interface IDaoCarrito: IDao<Carrito>
    {
        void InsertarDetalle(Detalle detalle);
        void ModificarDetalle(Detalle detalle);
        void BorrarDetalle(long id);
    }
}
