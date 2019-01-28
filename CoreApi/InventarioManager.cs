using AccesoDatos.CrudFactory;
using EntidadesPOJO;
using Excepciones;
using System;
using System.Collections.Generic;

namespace CoreApi
{
    public class InventarioManager: BaseManager
    {
        public InventarioCrudFactory crudFactory;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public InventarioManager()
        {
            crudFactory = new InventarioCrudFactory();
        }

        /// <summary>
        /// Agrega un producto al inventario.
        /// </summary>
        /// <param name="entity"></param>
        public void Crear(BaseEntity entity)
        {
            try
            {
                crudFactory.Create(entity);
            }
            catch (Exception error)
            {
                ExceptionManager.GetInstance().Process(error);
            }
        }
        /// <summary>
        /// Obtiene el inventario de una tienda.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public List<Inventario> ObtenerInventarioPorTienda(BaseEntity entity)
        {
            List<Inventario> inventario = null;

            try
            {
                inventario = crudFactory.ObtenerInventario<Inventario>(entity);

                if(inventario == null)
                {
                    throw new BussinessException(12);
                }
            }
            catch (Exception error)
            {
                ExceptionManager.GetInstance().Process(error);
            }

            return inventario;
        }

        /// <summary>
        /// Actualiza un producto del inventario de una tienda.
        /// </summary>
        /// <param name="entity"></param>
        public void Actualizar(BaseEntity entity)
        {
            crudFactory.Update(entity);
        }

        /// <summary>
        /// Elimina un producto del inventario de una tienda.
        /// </summary>
        /// <param name="entity"></param>
        public void Eliminar(BaseEntity entity)
        {
            crudFactory.Delete(entity);
        }
    }
}
