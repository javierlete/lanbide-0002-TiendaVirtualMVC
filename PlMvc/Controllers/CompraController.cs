using Entidades;
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

        public ActionResult AgregarCarrito(long id, int cantidad)
        {
            Carrito carrito = Bll.CarritoBll.Obtener((Entidades.Usuario)Session["usuario"]);

            Bll.CarritoBll.AgregarProducto(carrito.Id.Value, id, cantidad);

            return RedirectToAction("Carrito");
        }

        public ActionResult BorrarProducto(long id)
        {
            Carrito carrito = Bll.CarritoBll.Obtener((Entidades.Usuario)Session["usuario"]);

            Bll.CarritoBll.BorrarDetalle(carrito.Id.Value, id);

            return RedirectToAction("Carrito");
        }
        public ActionResult Carrito()
        {
            Carrito carrito = Bll.CarritoBll.Obtener((Entidades.Usuario)Session["usuario"]);

            return View(carrito);
        }
    }
}