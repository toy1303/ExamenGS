namespace APIGS.Modelo
{
    public class VentasCliente
    {
        public string clave { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public DateTime Fechaventa { get; set; }
        public decimal TotalVenta { get; set; }
        public int IdVenta { get; set; }
    }
}
