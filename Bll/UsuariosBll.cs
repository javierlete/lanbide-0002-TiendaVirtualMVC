using Dal;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public static class UsuariosBll
    {
        private static readonly IDaoUsuario dao = FabricaDaos.ObtenerDaoUsuario(Tipos.Entity);
        /// <summary>
        /// Verifica las credenciales pasadas de Email y Password y si son correctas devuelve el usuario con todos sus datos
        /// </summary>
        /// <param name="usuario">Objeto que contiene Email y Password a verificar</param>
        /// <returns>Usuario con todos sus datos si está verificado y null en el caso de que no esté verificado</returns>
        public static Usuario Verificar(Usuario usuario)
        {
            Usuario aVerificar = dao.ObtenerPorEmail(usuario.Email);

            if(aVerificar != null && usuario.Password == aVerificar.Password)
            {
                return aVerificar;
            }

            return null;
        }

        public static Usuario BuscarPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public static Usuario BuscarPorId(long id)
        {
            throw new NotImplementedException();
        }

        public static Usuario Alta(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
