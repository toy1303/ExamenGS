namespace APIGS.Modelo
{
    public class DeTalleVentas
    {
       public int IdVenta { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal Total { get; set; }
       
    }
}
