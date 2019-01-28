using CoreApi;
using EntidadesPOJO;
using Excepciones;
using System;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class InventarioController : ApiController
    {
        public ApiResponse apiRes = new ApiResponse();

        public IHttpActionResult Post(Inventario inventario)
        {
            try
            {
                apiRes = new ApiResponse();
                var mng = new InventarioManager();
                mng.Crear(inventario);
                apiRes.Message = "Se ha registrado exitosamente en el inventario de la tienda";
                return Ok(apiRes);
            }
            catch (BussinessException error)
            {
                return InternalServerError(new Exception(error.ExceptionId + "-" + error.AppMessage.Message));
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerInventario(string tienda)
        {
            try
            {
                var nuevoInventario = new Inventario() { IdTienda = tienda };
                apiRes = new ApiResponse();
                var mng = new InventarioManager();
                apiRes.Data = mng.ObtenerInventarioPorTienda(nuevoInventario);
                return Ok(apiRes);
            }
            catch (BussinessException error)
            {
                return InternalServerError(new Exception(error.ExceptionId + "-" + error.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Inventario inventario)
        {
            try
            {
                apiRes = new ApiResponse();
                var mng = new InventarioManager();
                mng.Actualizar(inventario);
                apiRes.Message = "Se ha actualizado exitosamente en el inventario de la tienda";
                return Ok(apiRes);
            }
            catch (BussinessException error)
            {
                return InternalServerError(new Exception(error.ExceptionId + "-" + error.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Inventario inventario)
        {
            try
            {
                apiRes = new ApiResponse();
                var mng = new InventarioManager();
                mng.Eliminar(inventario);
                apiRes.Message = "Se ha eliminado exitosamente en el inventario de la tienda";
                return Ok(apiRes);
            }
            catch (BussinessException error)
            {
                return InternalServerError(new Exception(error.ExceptionId + "-" + error.AppMessage.Message));
            }
        }
    }
}
