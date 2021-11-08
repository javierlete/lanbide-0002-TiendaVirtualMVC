using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal class DaoEntityUsuario : IDaoUsuario
    {
        public void Borrar(long id)
        {
            throw new NotImplementedException();
        }

        public Usuario Insertar(Usuario objeto)
        {
            throw new NotImplementedException();
        }

        public Usuario Modificar(Usuario objeto)
        {
            throw new NotImplementedException();
        }

        public Usuario ObtenerPorEmail(string email)
        {
            using(MF0968Context db = new MF0968Context())
            {
                return db.Usuarios.Where(u => u.Email == email).FirstOrDefault();
                // return (from u in db.Usuarios where u.Email == email select u).FirstOrDefault();
            }
        }

        public Usuario ObtenerPorId(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
