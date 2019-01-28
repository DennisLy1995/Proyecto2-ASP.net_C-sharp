using CoreApi;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class OpcionController : ApiController
    {
        public ApiResponse apiRes = new ApiResponse();

        public IHttpActionResult Get(string id)
        {
            try
            {
                id = id.ToLower();
                apiRes = new ApiResponse();
                var mng = new OpcionListaManager();
                apiRes.Data = mng.ListaSolicitada(id);
                return Ok(apiRes);
            }
            catch (BussinessException error)
            {
                return InternalServerError(new Exception(error.ExceptionId + "-" + error.AppMessage.Message));
            }
        }
    }
}
