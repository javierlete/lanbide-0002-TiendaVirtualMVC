using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlMvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(Bll.PublicoBll.ObtenerProductos());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Email,Password")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Usuario verificado = Bll.UsuariosBll.Verificar(usuario);

                if (verificado != null)
                {
                    Session["usuario"] = verificado;
                    return RedirectToAction("Index");
                }
            }

            return View(usuario);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}