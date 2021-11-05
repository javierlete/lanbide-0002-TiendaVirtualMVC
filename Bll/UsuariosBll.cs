using Dal;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class UsuariosBll
    {
        private static readonly IDaoUsuario dao = FabricaDaos.ObtenerDaoUsuario(Tipos.Entity);
       
        public Usuario verificar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(long id)
        {
            throw new NotImplementedException();
        }

        public Usuario Alta(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
