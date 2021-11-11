using Dal;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace Bll
{
    [TestClass]
    public class ProductosBllTest
    {
        private DbConnection ObtenerConexion()
        {
            return new SqlConnection(System.Configuration.ConfigurationManager.
                ConnectionStrings["MF0968Context"].ConnectionString);
        }
        
        [TestMethod]
        public void Consultar()
        {
            List<Producto> productos = ProductosBll.Consultar(new Usuario() { Rol = "ADMIN" }) as List<Producto>;

            Assert.IsNotNull(productos);

            Assert.ThrowsException<UnauthorizedAccessException>(() => ProductosBll.Consultar(new Usuario() { Rol = "USER" }));

            using (DbConnection con = ObtenerConexion())
            {
                con.Open();

                DbCommand com = con.CreateCommand();
                com.CommandText = "SELECT COUNT(*) FROM Productos";

                int cuenta = (int)com.ExecuteScalar();

                Assert.AreEqual(cuenta, productos.Count);

                com.CommandText = "SELECT * FROM Productos";

                DbDataReader dr = com.ExecuteReader();

                int i = 0;

                while (dr.Read())
                {
                    Assert.AreEqual(dr["Id"], productos[i].Id);
                    Assert.AreEqual(dr["Nombre"], productos[i].Nombre);
                    Assert.AreEqual(dr["Precio"], productos[i].Precio);
                    //Assert.AreEqual(dr["FechaCaducidad"], productos[i].FechaCaducidad);

                    i++;
                }
            }
        }
    }
}
