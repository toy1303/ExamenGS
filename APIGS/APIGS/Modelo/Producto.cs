using System;

namespace APIGS.Modelo
{
    public class Producto
    {

        public int PRODUCTO_ID  {get; set;}
        public string DESCRIPCION { get; set; }
        public decimal  COSTO_UNITARIO { get; set; }
        public string ESTATUS { get; set; }
    }
}
