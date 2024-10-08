using APIGS.Entrada;
using APIGS.Helpers;
using APIGS.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace APIGS.Controllers
{
    [Produces("application/json")]
    public class VentasClienteController : Controller
    {
        private readonly ConectionOracle _dbConnection;

        public VentasClienteController(ConectionOracle dbConnection)
        {
            _dbConnection = dbConnection;
        }


        [HttpPost]
        [Route("Agregaventa")]
        public IActionResult Agregaventa([FromBody] Venta venta)
        {
            _dbConnection.InsertaVenta(venta.ClienteId,venta.ProductoId,venta.cantidad);
            return Ok("Venta Exitosa");
        }


        [HttpGet]
        [Route("Obtieneventas")]
        public IActionResult Obtieneventas()
        {
            string query = "select * from  vw_VentasPorCliente";
            List<VentasCliente> ventasClientes = _dbConnection.GetventasClientes(query);
            return Ok(ventasClientes);
        }

        [HttpGet]
        [Route("DetalleVenta/{Id}")]
        public IActionResult DetalleVenta(int Id)
        {
            string query = string.Format("SELECT * FROM vista_detalle_venta WHERE venta_ID={0}", Id);
            List<DeTalleVentas> detalleventa = _dbConnection.DeTalleVentas(query);
            return Ok(detalleventa);
        }
    }
}
