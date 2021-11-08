using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiTiendaVirtual.Controllers
{
    public class ProductosController : ApiController
    {
        public IEnumerable<Producto> Get()
        {
            return Bll.PublicoBll.ObtenerProductos();
        }
    }
}
