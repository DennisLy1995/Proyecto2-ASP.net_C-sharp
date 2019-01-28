using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesPOJO
{
    public class Distribuidor : BaseEntity
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public double TarifaBase { get; set; }
        public double TarifaKM { get; set; }
        public int Rango { get; set; } //Averiguar como se hace
        public string Administrador { get; set; }

    }
}
