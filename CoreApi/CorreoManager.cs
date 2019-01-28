using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.CrudFactory;
using EntidadesPOJO;

namespace CoreApi
{
    public class CorreoManager : BaseManager
    {
        private CorreoCrudFactory crud;

        public CorreoManager()
        {
            crud = new CorreoCrudFactory();
        }

        public List<Correo> RetrieveAll()
        {
            return crud.RetrieveAll<Correo>();
        }
    }
}
