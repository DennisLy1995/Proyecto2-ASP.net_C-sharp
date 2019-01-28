using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesPOJO
{
    public class Productos : BaseEntity
    {

        public int CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public string TIPO { get; set; }
        public int CODIGO_CATEGORIA { get; set; }
        public int CODIGO_TIENDA { get; set; }
        public string DESCRIPCION { get; set; }

        public Productos()
        {

        }

    }
}
