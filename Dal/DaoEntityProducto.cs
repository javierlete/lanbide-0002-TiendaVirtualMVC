using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DaoEntityProducto : IDaoProducto
    {
        public void Borrar(long id)
        {
            using (MF0968Context db = new MF0968Context())
            {
                db.Productos.Remove(db.Productos.Find(id));
                db.SaveChanges();
            }
        }

        public Producto Insertar(Producto producto)
        {
            using (MF0968Context db = new MF0968Context())
            {
                db.Productos.Add(producto);
                db.SaveChanges();
                return producto;
            }
        }

        public Producto Modificar(Producto producto)
        {
            using (MF0968Context db = new MF0968Context())
            {
                db.Entry(producto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return producto;
            }
        }

        public Producto ObtenerPorId(long id)
        {
            using (MF0968Context db = new MF0968Context())
            {
                return db.Productos.Find(id);
            }
        }

        public IEnumerable<Producto> ObtenerTodos()
        {
            using (MF0968Context db = new MF0968Context())
            {
                return db.Productos.ToList();
            }
        }
    }
}
