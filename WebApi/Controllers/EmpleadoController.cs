using CoreApi;
using EntidadesPOJO;
using Excepciones;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ExceptionFilter]
    public class EmpleadoController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get(String idUsuario, String idTienda)
        {
            try
            {
                var mng = new EmpleadoManager();
                var empleado = new Empleado
                {
                    IDENTIFICACION = idUsuario,
                    ID_TIENDA = idTienda
                };

                empleado = mng.RetrieveById(empleado);
                apiResp = new ApiResponse();
                apiResp.Data = empleado;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

               
        public IHttpActionResult Get(string idTienda)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new EmpleadoManager();
                var empleado = new Empleado
                {
                    ID_TIENDA = idTienda
                };
                apiResp.Data = mng.RetrieveAllEmpleadosTienda(empleado);
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Empleado entidad)
        {

            try
            {
                var mng = new EmpleadoManager();
                mng.Create(entidad);

                apiResp = new ApiResponse();
                apiResp.Message = "Los datos del empleado han sido registrados";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Empleado entidad)
        {
            try
            {
                var mng = new EmpleadoManager();
                mng.Delete(entidad);
                apiResp = new ApiResponse();//
                apiResp.Message = "El empleado fue eliminado.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Empleado entidad)
        {
            try
            {
                var mng = new EmpleadoManager();
                mng.Update(entidad);

                apiResp = new ApiResponse();
                apiResp.Message = "Los datos han sido modificados.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
