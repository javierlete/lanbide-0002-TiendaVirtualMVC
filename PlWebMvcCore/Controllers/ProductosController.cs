using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlWebMvcCore.Controllers
{
    public class ProductosController : Controller
    {
        // GET: ProductosController
        public ActionResult Index()
        {
            //var productos = new List<Producto>() {
            //    new Producto() { Nombre = "Prueba Seed", Precio = 1123.45m, FechaCaducidad = DateTime.Now },
            //    new Producto() { Nombre = "Prueba 2", Precio = 223.45m, FechaCaducidad = DateTime.Now }
            //};

            var productos = Bll.ProductosBll.Consultar();

            return View(productos);
        }
    }
}
