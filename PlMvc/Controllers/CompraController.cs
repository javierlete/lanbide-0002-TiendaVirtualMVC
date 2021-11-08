using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlMvc.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult DetalleProducto(long id)
        {
            return View(Bll.PublicoBll.BuscarProductoPorId(id));
        }

        public ActionResult AgregarCarrito(long id)
        {
            return View();
        }
    }
}