using CoreApi;
using EntidadesPOJO;
using Excepciones;
using System;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class DistribuidorController : ApiController
    {

        public ApiResponse apiRes;

        public IHttpActionResult Post(Distribuidor entidad)
        {
            try
            {
                apiRes = new ApiResponse();
                var mng = new DistribuidorManager();
                mng.Registrar(entidad);
                apiRes.Message = "El distribuidor " + entidad.Nombre + " se registró con éxito";
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
                var mng = new DistribuidorManager();
                apiRes.Data = mng.ObtenerDistribuidores();
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
                apiRes = new ApiResponse();
                var mng = new DistribuidorManager();
                var nuevoObj = new Distribuidor() { Cedula = id };
                apiRes.Data = mng.ObtenerPorCedula(nuevoObj);
                return Ok(apiRes);
            }
            catch (BussinessException error)
            {
                return InternalServerError(new Exception(error.ExceptionId + "-" + error.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Distribuidor entidad)
        {
            try
            {
                apiRes = new ApiResponse();
                var mng = new DistribuidorManager();
                mng.Actualizar(entidad);
                apiRes.Message = "El distribuidor " + entidad.Nombre + "se actualizó con éxito";
                return Ok(apiRes);
            }
            catch (BussinessException error)
            {
                return InternalServerError(new Exception(error.ExceptionId + "-" + error.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Distribuidor entidad)
        {
            try
            {
                apiRes = new ApiResponse();
                var mng = new DistribuidorManager();
                mng.Eliminar(entidad);
                apiRes.Message = "El distribuidor " + entidad.Nombre + "se eliminó con éxito";
                return Ok(apiRes);
            }
            catch (BussinessException error)
            {
                return InternalServerError(new Exception(error.ExceptionId + "-" + error.AppMessage.Message));
            }
        }

        [HttpGet]
        [Route("api/distribuidor/ObtenerPorAdmin/{idAdmin}")]
        public IHttpActionResult ObtenerPorAdmin(string idAdmin)
        {
            try
            {
                apiRes = new ApiResponse();
                var mng = new DistribuidorManager();
                var nuevoObj = new Distribuidor() { Administrador = idAdmin };
                apiRes.Data = mng.ObtenerPorAdmin(nuevoObj);
                return Ok(apiRes);
            }
            catch (BussinessException error)
            {
                return InternalServerError(new Exception(error.ExceptionId + "-" + error.AppMessage.Message));
            }
        }
    }
}
