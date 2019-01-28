using CoreApi;
using EntidadesPOJO;
using Excepciones;
using System;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class TiendaController : ApiController
    {
        public ApiResponse apiRes;

        public IHttpActionResult Post(Tienda entity)
        {
            try
            {
                apiRes = new ApiResponse();
                var mng = new TiendaManager();
                mng.Crear(entity);
                apiRes.Message = "La tienda " + entity.Nombre + " se registró exitosamente.";
                return Ok(apiRes);
            }
            catch (BussinessException error)
            {
                return InternalServerError(new Exception(error.ExceptionId + "-" + error.AppMessage.Message));
            }
        }

        public IHttpActionResult Get()
        {
            try
            {
                apiRes = new ApiResponse();
                var mng = new TiendaManager();
                apiRes.Data = mng.ObtenerTodasTiendas();
                return Ok(apiRes);
            }
            catch (BussinessException error)
            {
                return InternalServerError(new Exception(error.ExceptionId + "-" + error.AppMessage.Message));
            }
        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                var obj = new Tienda() { Cedula = id };
                apiRes = new ApiResponse();
                var mng = new TiendaManager();
                apiRes.Data = mng.ObtenerPorCedula(obj);
                return Ok(apiRes);
            }
            catch (BussinessException error)
            {
                return InternalServerError(new Exception(error.ExceptionId + "-" + error.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Tienda entity)
        {
            try
            {
                apiRes = new ApiResponse();
                var mng = new TiendaManager();
                mng.Actualizar(entity);
                apiRes.Message = "La tienda " + entity.Nombre + " se actualizó exitosamente.";
                return Ok(apiRes);
            }
            catch (BussinessException error)
            {
                return InternalServerError(new Exception(error.ExceptionId + "-" + error.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Tienda entity)
        {
            try
            {
                apiRes = new ApiResponse();
                var mng = new TiendaManager();
                mng.Eliminar(entity);
                apiRes.Message = "La tienda " + entity.Nombre + " se eliminó exitosamente.";
                return Ok(apiRes);
            }
            catch (BussinessException error)
            {
                return InternalServerError(new Exception(error.ExceptionId + "-" + error.AppMessage.Message));
            }
        }

        [HttpPost]
        [Route("api/tienda/AsociarCategoria")]
        public IHttpActionResult AsociarCategoria(string idTienda, int idCategoria)
        {
            try
            {
                apiRes = new ApiResponse();
                var mng = new TiendaManager();
                mng.AsociarCategoria(idTienda, idCategoria);
                apiRes.Message = "Se asoció la categoría a la tienda con éxito";
                return Ok(apiRes);
            }
            catch (BussinessException error)
            {
                return InternalServerError(new Exception(error.ExceptionId + "-" + error.AppMessage.Message));
            }
        }
        
        [HttpPost]
        [Route("api/tienda/AsociarDistribuidor")]
        public IHttpActionResult AsociarDistribuidor(string idTienda, string idDistribuidor)
        {
            try
            {
                apiRes = new ApiResponse();
                var mng = new TiendaManager();
                mng.AsociarDistribuidor(idTienda, idDistribuidor);
                apiRes.Message = "Se asoció el distribuidor a la tienda con éxito";
                return Ok(apiRes);
            }
            catch (BussinessException error)
            {
                return InternalServerError(new Exception(error.ExceptionId + "-" + error.AppMessage.Message));
            }
        }

        [HttpGet]
        [Route("api/tienda/ObtenerCategorias")]
        public IHttpActionResult ObtenerCategorias(string idTienda)
        {
            try
            {
                apiRes = new ApiResponse();
                var mng = new TiendaManager();
                apiRes.Data = mng.ObtenerCategorias(idTienda);
                return Ok(apiRes);
            }
            catch (BussinessException error)
            {
                return InternalServerError(new Exception(error.ExceptionId + "-" + error.AppMessage.Message));
            }
        }

        [HttpGet]
        [Route("api/tienda/ObtenerDistribuidores")]
        public IHttpActionResult ObtenerDistribuidores(string idTienda)
        {
            try
            {
                apiRes = new ApiResponse();
                var mng = new TiendaManager();
                apiRes.Data = mng.ObtenerDistribuidores(idTienda);
                return Ok(apiRes);
            }
            catch (BussinessException error)
            {
                return InternalServerError(new Exception(error.ExceptionId + "-" + error.AppMessage.Message));
            }
        }

        [HttpPut]
        [Route("api/tienda/EliminarDistribuidor")]
        public IHttpActionResult EliminarDistribuidor(string idTienda, string idDistribuidor)
        {
            try
            {
                apiRes = new ApiResponse();
                var mng = new TiendaManager();
                mng.EliminarDistribuidor(idTienda, idDistribuidor);
                apiRes.Message = "Se desasoció el distribuidor con éxito.";
                return Ok(apiRes);
            }
            catch (BussinessException error)
            {
                return InternalServerError(new Exception(error.ExceptionId + "-" + error.AppMessage.Message));
            }
        }
    }
}
