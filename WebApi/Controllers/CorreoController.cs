using CoreApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CorreoController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // GET api/account
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new CorreoManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }
    }
}
