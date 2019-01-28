using System.Collections.Generic;

namespace EntidadesPOJO
{
    public class Tienda : BaseEntity
    {
        public string Cedula { get; set; }
        public string TipoCedula { get; set; }
        public string Nombre { get; set; }
        public string UrlLogo { get; set; }
        public int GpsBodega { get; set; } //Id del Gps
        public string CodigoVendedor { get; set; } // Se reemplazara por un objeto usuario.
        public double Comision { get; set; }
        public List<Inventario> Inventario { get; set; }
        public List<Distribuidor> Distribuidores { get; set; }
        //Falta agregar categorias
    }
}
