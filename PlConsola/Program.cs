using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            var productos = Bll.ProductosBll.Consultar();

            foreach (var producto in productos)
            {
                Console.WriteLine(producto);
            }
        }
    }
}
