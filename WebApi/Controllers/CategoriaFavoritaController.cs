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
    public class CategoriaFavoritaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        [HttpGet]
        public IHttpActionResult Get(string idUsuario)
        {

            try
            {
                apiResp = new ApiResponse();
                var mng = new CategoriaFavoritaManager();
                var catFav = new CategoriaFavorita
                {
                    IdUsuario = idUsuario
                };
                apiResp.Data = mng.RetrieveAllCategoriasUsuario(catFav);
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(CategoriaFavorita entidad)
        {
            try
            {
                var mng = new CategoriaFavoritaManager();
                mng.Create(entidad);

                apiResp = new ApiResponse();
                apiResp.Message = "Categoría favorita registrada";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(CategoriaFavorita entidad)
        {
            try
            {
                var mng = new CategoriaFavoritaManager();
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
