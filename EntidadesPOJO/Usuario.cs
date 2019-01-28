using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesPOJO
{
    public class Usuario :BaseEntity
    {
        public string IDENTIFICACION { get; set; }
        public int CODIGO_CORREO { get; set; }
        public string PRIMER_NOMBRE { get; set; }
        public string SEGUNDO_NOMBRE { get; set; }
        public string PRIMER_APELLIDO { get; set; }
        public string SEGUNDO_APELLIDO { get; set; }
        public string URL_FOTO_PERFIL { get; set; }
        public string URL_FOTO_ID { get; set; }
        public string TIPO_CUENTA { get; set; }
        public int CODIGO_GPS { get; set; }
        public int NUM_CUENTA { get; set; }
        public string CONTRASENNA { get; set; }
        public string EMAIL { get; set; }
    }
}
