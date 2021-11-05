﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface IDaoUsuario: IDao<Usuario>
    {
        Usuario ObtenerPorEmail(string email);
    }
}
