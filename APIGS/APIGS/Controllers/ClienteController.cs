using APIGS.Helpers;
using APIGS.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace APIGS.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ConectionOracle _dbConnection;

        public ClienteController(ConectionOracle dbConnection)
        {
            _dbConnection = dbConnection;
        }

        [HttpGet]
        [Route("ObtieneclientesActivos")]
        public IActionResult VentasCliente()
        {
            string query = "select * from CLIENTE";
            List<Cliente> clientes = _dbConnection.GetClienteList(query);
            clientes= (from cli in clientes
                              where cli.ESTATUS=="ACTIVO"
                       select cli).ToList();
            return Ok(clientes);
        }
    }
}
