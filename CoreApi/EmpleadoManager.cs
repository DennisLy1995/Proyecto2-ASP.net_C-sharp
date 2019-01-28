using AccesoDatos.CrudFactory;
using EntidadesPOJO;
using Excepciones;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApi
{
    public class EmpleadoManager : BaseManager
    {
        private EmpleadoCrudFactory crud;

        public EmpleadoManager()
        {
            crud = new EmpleadoCrudFactory();
        }

        public void Create(Empleado entidad)
        {

            entidad.ID_TIENDA = "1"; //Tener pendiente de borrar

            try
            {
                var c = crud.Retrieve<Empleado>(entidad);

                if (c != null)
                {

                }
                else
                {
                    crud.Create(entidad);
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Empleado> RetrieveAllEmpleadosTienda(Empleado empleado)
        {
            List<Empleado> e = null;

            try
            {
               e = crud.RetrieveAllEmpleadosTienda<Empleado>(empleado);
                if (e == null)
                {
                    throw new BusinessException(0);
                }
            }
            catch(Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return crud.RetrieveAllEmpleadosTienda<Empleado>(empleado);
        }

        public void Delete(Empleado entidad)
        {

            entidad.ID_TIENDA = "1"; //Tener pendiente de borrar

            crud.Delete(entidad);
        }

        public Empleado RetrieveById(Empleado entidad)
        {
            Empleado e = null;
            try
            {
                e = crud.Retrieve<Empleado>(entidad);
                if (e == null)
                {
                    throw new BusinessException(0);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return e;
        }

        public void Update(Empleado entidad)
        {
            entidad.ID_TIENDA = "1"; //Tener pendiente de borrar

            crud.Update(entidad);
        }
    }
}
