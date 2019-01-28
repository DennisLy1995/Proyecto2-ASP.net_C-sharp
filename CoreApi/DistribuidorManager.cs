using AccesoDatos.CrudFactory;
using EntidadesPOJO;
using Excepciones;
using System;
using System.Collections.Generic;

namespace CoreApi
{
    public class DistribuidorManager : BaseManager
    {
        public DistribuidorCrudFactory crudFactory;

        public DistribuidorManager()
        {
            crudFactory = new DistribuidorCrudFactory();
        }

        /// <summary>
        /// Registra un distribuidor al sistema.
        /// </summary>
        /// <param name="entity"></param>
        public void Registrar(BaseEntity entity)
        {
            try
            {
                var resultado = crudFactory.Retrieve<Distribuidor>(entity);

                if(resultado == null)
                {
                    crudFactory.Create(entity);
                } else
                {
                    throw new BussinessException(13);
                }
            }
            catch (Exception error)
            {
                ExceptionManager.GetInstance().Process(error);
            }
        }

        /// <summary>
        /// Actualiza un distribuidor.
        /// </summary>
        /// <param name="entity"></param>
        public void Actualizar(BaseEntity entity)
        {
            crudFactory.Update(entity);
        }

        /// <summary>
        /// Obtiene todos los distribuidores del sistema.
        /// </summary>
        /// <returns></returns>
        public List<Distribuidor> ObtenerDistribuidores()
        {
            return crudFactory.RetrieveAll<Distribuidor>();
        }

        /// <summary>
        /// Obtiene un distribuidor por medio de la cedula.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Distribuidor ObtenerPorCedula(BaseEntity entity)
        {
            Distribuidor obj = null;

            try
            {
                obj = crudFactory.Retrieve<Distribuidor>(entity);

                if(obj == null)
                {
                    throw new BussinessException(14);
                }
            }
            catch (Exception error)
            {
                ExceptionManager.GetInstance().Process(error);
            }

            return obj;
        }

        /// <summary>
        /// Elimina un distribuidor del sistema
        /// </summary>
        /// <param name="entity"></param>
        public void Eliminar(BaseEntity entity)
        {
            crudFactory.Delete(entity);
        }

        public Distribuidor ObtenerPorAdmin(BaseEntity entity)
        {
            Distribuidor obj = null;

            try
            {
                obj = crudFactory.ObtenerDistribuidorPorAdmin<Distribuidor>(entity);

                if (obj == null)
                {
                    throw new BussinessException(14);
                }
            }
            catch (Exception error)
            {
                ExceptionManager.GetInstance().Process(error);
            }

            return obj;
        }
    }
}
