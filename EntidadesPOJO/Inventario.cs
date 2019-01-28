using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesPOJO
{   
    public class Inventario : BaseEntity
    {
        public int Codigo { get; set; }
        public string IdProducto { get; set; }// Cuando exista objeto producto, se reemplaza
        public string IdTienda { get; set; }
        public string FechaEntrada { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnidad { get; set; }
        public double Impuesto { get; set; }
        // Cuando exista objeto proveedor, se reemplaza
        public string IdProveedor { get; set; }
    }
}
