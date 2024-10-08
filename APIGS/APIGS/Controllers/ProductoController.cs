using APIGS.Helpers;
using APIGS.Modelo;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.Common;

namespace APIGS.Controllers
{

    [Produces("application/json")]
    public class ProductoController : Controller
    {
        private readonly ConectionOracle _dbConnection;


        public ProductoController(ConectionOracle dbConnection)
        {
            _dbConnection = dbConnection;
        }

        [HttpGet]
        [Route("ObtieneProductos")]
        public IActionResult ObtieneProductos()
        {
            string query = "select * from Producto";
            List<Producto> Productos= _dbConnection.GetProductos(query);
            return Ok(Productos);
        }


    }
}
