using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal class DaoEntityCarrito : IDaoCarrito
    {
        public void Borrar(long id)
        {
            using (MF0968Context db = new MF0968Context())
            {
                db.Carritos.Remove(db.Carritos.Find(id));
                db.SaveChanges();
            }
        }

        public void BorrarDetalle(long id)
        {
            throw new NotImplementedException();
        }

        public Carrito Insertar(Carrito carrito)
        {
            using (MF0968Context db = new MF0968Context())
            {
                db.Entry(carrito.Usuario).State = System.Data.Entity.EntityState.Unchanged;
                db.Carritos.Add(carrito);
                db.SaveChanges();

                return carrito;
            }
        }

        public void InsertarDetalle(Carrito.Detalle detalle)
        {
            using(MF0968Context db = new MF0968Context())
            {
                db.Detalles.Add(detalle);
                db.SaveChanges();
            }
        }

        public Carrito Modificar(Carrito carrito)
        {
            throw new NotSupportedException("No es una operación válida para carrito");
        }

        public void ModificarDetalle(Carrito.Detalle detalle)
        {
            throw new NotImplementedException();
        }

        public Carrito ObtenerPorId(long id)
        {
            using (MF0968Context db = new MF0968Context())
            {
                return db.Carritos.Include("Usuario").Include("Detalles").Include("Detalles.Producto").FirstOrDefault(c => c.Id == id);
            }
        }

        public IEnumerable<Carrito> ObtenerTodos()
        {
            using (MF0968Context db = new MF0968Context())
            {
                return db.Carritos.ToList();
            }
        }
    }
}
