
using Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi;
using WebApi.Models;
using CoreApi;
using EntidadesPOJO;
using Excepciones;

namespace WebApi.Controllers
{
    [ExceptionFilter]
    public class UsuarioController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/account
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new UsuarioManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        // GET api/account/5
        public IHttpActionResult Get(String id)
        {
            try
            {
                var mng = new UsuarioManager();
                var account = new Usuario
                {
                    IDENTIFICACION = id
                };

                account = mng.RetrieveById(account);
                apiResp = new ApiResponse();
                apiResp.Data = account;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Get(String id, int status)
        {
            /* Desactiva la cuenta*/
            try
            {
                var mng = new UsuarioManager();
                var account = new Usuario
                {
                    IDENTIFICACION = id
                };

                mng.Delete(account);
                apiResp = new ApiResponse();
                apiResp.Data = "Ok";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Get(String email, String password)
        {
            try
            {
                var mng = new UsuarioManager();
                var account = new Usuario
                {
                    EMAIL = email,
                    CONTRASENNA = password
                };

                apiResp = new ApiResponse();
                apiResp.Data = mng.IniciarSesion(account);
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }



        // POST 
        public IHttpActionResult Post(Usuario entidad)
        {

            try
            {
                var mng = new UsuarioManager();
                mng.Create(entidad);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // PUT
        public IHttpActionResult Put(Usuario entidad)
        {
            try
            {
                var mng = new UsuarioManager();
                mng.Update(entidad);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // DELETE
        public IHttpActionResult Delete(Usuario entidad)
        {
            try
            {
                var mng = new UsuarioManager();
                mng.Delete(entidad);
                apiResp = new ApiResponse();//
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
