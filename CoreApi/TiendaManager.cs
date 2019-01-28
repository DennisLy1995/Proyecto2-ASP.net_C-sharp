using AccesoDatos.CrudFactory;
using EntidadesPOJO;
using Excepciones;
using System;
using System.Collections.Generic;

namespace CoreApi
{
    public class TiendaManager : BaseManager
    {
        public TiendaCrudFactory crudFactory;

        public TiendaManager()
        {
            crudFactory = new TiendaCrudFactory();
        }

        /// <summary>
        /// Registra una tienda en el sistema.
        /// </summary>
        /// <param name="entity"></param>
        public void Crear(BaseEntity entity)
        {
            try
            {
                var resultado = crudFactory.Retrieve<Tienda>(entity);

                if(resultado != null)
                {
                    throw new BussinessException(10);
                } else
                {
                    crudFactory.Create(entity);
                }
            }
            catch (Exception error)
            {
                ExceptionManager.GetInstance().Process(error);
            }
        }

        /// <summary>
        /// Obtiene una tienda por medio de la cédula.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Tienda ObtenerPorCedula(BaseEntity entity)
        {
            Tienda obj = null;

            try
            {
                obj = crudFactory.Retrieve<Tienda>(entity);

                if (obj == null)
                {
                    throw new BussinessException(11);
                }
            }
            catch (Exception error)
            {
                ExceptionManager.GetInstance().Process(error);
            }

            return obj;
        }

        /// <summary>
        /// Obtiene todas las tiendas registradas del sistema.
        /// </summary>
        /// <returns></returns>
        public List<Tienda> ObtenerTodasTiendas()
        {
            return crudFactory.RetrieveAll<Tienda>();
        }

        /// <summary>
        /// Actualiza los datos de una tienda especifica.
        /// </summary>
        /// <param name="entity"></param>
        public void Actualizar(BaseEntity entity)
        {
            crudFactory.Update(entity);
        }

        /// <summary>
        /// Elimina una tienda del sistema.
        /// </summary>
        /// <param name="entity"></param>
        public void Eliminar(BaseEntity entity)
        {
            crudFactory.Delete(entity);
        }

        /// <summary>
        /// Asocia una categoría a una tienda especifica.
        /// </summary>
        /// <param name="idTienda">Código único de la tienda</param>
        /// <param name="idCategoria">Código único de la categoría</param>
        public void AsociarCategoria(string idTienda, int idCategoria)
        {
            try
            {
                var obj = new Tienda() { Cedula = idTienda };
                var tiendaExiste = crudFactory.Retrieve<Tienda>(obj);

                if(tiendaExiste == null)
                {
                    throw new BussinessException(11);
                } else
                {
                    crudFactory.AsociarCategoria(idTienda, idCategoria);
                }
            }
            catch (Exception error)
            {
                ExceptionManager.GetInstance().Process(error);
            }
        }

        /// <summary>
        /// Asocia un distribuidor a una tienda especifica.
        /// </summary>
        /// <param name="idTienda">Código único de la tienda</param>
        /// <param name="idDistribuidor">Código único del distribuidor</param>
        public void AsociarDistribuidor(string idTienda, string idDistribuidor)
        {
            try
            {
                var obj = new Tienda() { Cedula = idTienda };
                var tiendaExiste = crudFactory.Retrieve<Tienda>(obj);

                if (tiendaExiste == null)
                {
                    throw new BussinessException(11);
                }
                else
                {
                    crudFactory.AsociarDistribuidor(idTienda, idDistribuidor);
                }
            }
            catch (Exception error)
            {
                ExceptionManager.GetInstance().Process(error);
            }
        }

        /// <summary>
        /// Obtiene todas las categorías de una tienda.
        /// </summary>
        /// <param name="idTienda"></param>
        /// <returns></returns>
        public List<Categorias> ObtenerCategorias(string idTienda)
        {
            return crudFactory.ObtenerCategorias<Categorias>(idTienda);
        }

        /// <summary>
        /// Obtiene todas los distribuidores de una tienda.
        /// </summary>
        /// <param name="idTienda"></param>
        /// <returns></returns>
        public List<Distribuidor> ObtenerDistribuidores(string idTienda)
        {
            return crudFactory.ObtenerDistribuidores<Distribuidor>(idTienda);
        }

        /// <summary>
        /// Desasocia un distribuidor de una tienda.
        /// </summary>
        /// <param name="idTienda"></param>
        /// <param name="idDistribuidor"></param>
        public void EliminarDistribuidor(string idTienda, string idDistribuidor)
        {
            crudFactory.EliminarDistribuidor(idTienda, idDistribuidor);
        }
    }
}
