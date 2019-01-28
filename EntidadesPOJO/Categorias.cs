using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesPOJO
{
    public class Categorias : BaseEntity
    {

        public int CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public string TAG { get; set; }

        public Categorias()
        {

        }

    }
}
