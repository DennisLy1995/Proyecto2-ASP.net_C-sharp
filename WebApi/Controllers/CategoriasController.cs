using CoreApi;
using EntidadesPOJO;
using Excepciones;
using System;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Categorias")]
    public class CategoriasController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        //Metodos get del controlador

        [HttpGet]
        public IHttpActionResult Get()
        {
            //[dbo].[RET_ALL_CATEGORIAS_PR]
            apiResp = new ApiResponse();
            var mng = new CategoriasManager();
            apiResp.Data = mng.RetrieveAll();
            apiResp.Message = "Successful";
            return Ok(apiResp);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            //[dbo].[RET_CATEGORIA_PR]
            try
            {
                var mng = new CategoriasManager();
                var categoria = new Categorias
                {
                    CODIGO = id
                };

                categoria = mng.RetrieveById(categoria);
                apiResp = new ApiResponse();
                apiResp.Data = categoria;
                apiResp.Message = "Successful";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        [HttpGet]
        [Route("CountByNombre/{nombreCategoria}")]
        public IHttpActionResult CountByNombre(string nombreCategoria)
        {
            //[dbo].[CONT_CATEGORIAS_BY_NOMBRE_PR]
            apiResp = new ApiResponse();
            var mng = new CategoriasManager();
            apiResp.Data = mng.CountByNombre(nombreCategoria);
            apiResp.Message = "Successful";
            return Ok(apiResp);
        }


        [HttpGet]
        [Route("CountByTag/{tag}")]
        public IHttpActionResult CountByTag(string tag)
        {
            //[dbo].[CONT_CATEGORIAS_BY_TAG_PR]
            apiResp = new ApiResponse();
            var mng = new CategoriasManager();
            apiResp.Data = mng.CountByTag(tag);
            apiResp.Message = "Successful";
            return Ok(apiResp);
        }


        [HttpGet]
        [Route("CountTotal")]
        public IHttpActionResult CountTotal()
        {
            //[dbo].[CONT_CATEGORIAS_PR]
            apiResp = new ApiResponse();
            var mng = new CategoriasManager();
            apiResp.Data = mng.CountAll();
            apiResp.Message = "Successful";
            return Ok(apiResp);
        }


        [HttpGet]
        [Route("RetAllByName/{nombreCategoria}")]
        public IHttpActionResult RetAllByName(string nombreCategoria)
        {
            //[dbo].[RET_ALL_CATEGORIAS_BY_NOMBRE_PR]
            apiResp = new ApiResponse();
            var mng = new CategoriasManager();
            apiResp.Data = mng.RetrieveAllByNombre(nombreCategoria);
            apiResp.Message = "Successful";
            return Ok(apiResp);
        }


        [HttpGet]
        [Route("RetAllByTag/{tag}")]
        public IHttpActionResult RetAllByTag(string tag)
        {
            //[dbo].[RET_ALL_CATEGORIAS_BY_TAG_PR]
            apiResp = new ApiResponse();
            var mng = new CategoriasManager();
            apiResp.Data = mng.RetrieveAllByTag(tag);
            apiResp.Message = "Successful";
            return Ok(apiResp);
        }



        // Metodos POST del controlador
        [HttpPost]
        public IHttpActionResult Post(Categorias categoria)
        {

            try
            {
                var mng = new CategoriasManager();
                mng.Create(categoria);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // Metodos PUT del controlador
        [HttpPut]
        public IHttpActionResult Put(Categorias categoria)
        {
            try
            {
                var mng = new CategoriasManager();
                mng.Update(categoria);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // Metodos DELETE del controlador
        [HttpDelete]
        public IHttpActionResult Delete(Categorias categoria)
        {
            try
            {
                var mng = new CategoriasManager();
                mng.Delete(categoria);

                apiResp = new ApiResponse();
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
