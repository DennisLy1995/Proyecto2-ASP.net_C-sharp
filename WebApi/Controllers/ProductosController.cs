using CoreApi;
using EntidadesPOJO;
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
    [RoutePrefix("api/Productos")]
    public class ProductosController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        [HttpGet]
        public IHttpActionResult Get()
        {
            //[dbo].[RET_ALL_PRODUCTOS_PR]
            apiResp = new ApiResponse();
            var mng = new ProductosManager();
            apiResp.Data = mng.RetrieveAll();
            apiResp.Message = "Successful";
            return Ok(apiResp);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            //[dbo].[RET_PRODUCTO_PR]
            try
            {
                var mng = new ProductosManager();
                var producto = new Productos
                {
                    CODIGO = id
                };

                producto = mng.RetrieveById(producto);
                apiResp = new ApiResponse();
                apiResp.Data = producto;
                apiResp.Message = "Successful";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }


        [HttpGet]
        [Route("ByCedulaTienda")]
        public IHttpActionResult ByCedulaTienda()
        {
            //[dbo].[CON_ALL_PRODUCTOS_BY_CEDULA_TIENDA_PR]
            apiResp = new ApiResponse();
            return Ok(apiResp);
        }

        [HttpGet]
        [Route("CountByNombreTienda/{nombreTienda}")]
        public IHttpActionResult CountByNombreTienda(string nombreTienda)
        {
            //[dbo].[CON_ALL_PRODUCTOS_BY_NOMBRE_TIENDA_PR]
            apiResp = new ApiResponse();
            var mng = new ProductosManager();
            apiResp.Data = mng.CountByNombreTienda(nombreTienda);
            apiResp.Message = "Successful";
            return Ok(apiResp);
        }

        [HttpGet]
        [Route("CountByCategoria/{codigoCategoria}")]
        public IHttpActionResult CountByCategoria(int codigoCategoria)
        {
            //[dbo].[CONT_ALL_PRODUCTOS_BY_CATEGORIA_PR]
            apiResp = new ApiResponse();
            var mng = new ProductosManager();
            apiResp.Data = mng.CountByCodigoTienda(codigoCategoria);
            apiResp.Message = "Successful";
            return Ok(apiResp);
        }

        [HttpGet]
        [Route("CountByTienda")]
        public IHttpActionResult CountByTienda(int codigoTienda,int codigoCategoria)
        {
            //[dbo].[CONT_ALL_PRODUCTOS_BY_TIENDA_PR]
            apiResp = new ApiResponse();
            var mng = new ProductosManager();
            apiResp.Data = mng.CountByTienda(codigoTienda, codigoCategoria);
            apiResp.Message = "Successful";
            return Ok(apiResp);
        }

        [HttpGet]
        [Route("CountAllProducts")]
        public IHttpActionResult CountAllProducts()
        {
            //[dbo].[CONT_ALL_PRODUCTOS_PR]
            apiResp = new ApiResponse();
            var mng = new ProductosManager();
            apiResp.Data = mng.CountAllProducts();
            apiResp.Message = "Successful";
            return Ok(apiResp);
        }


        [HttpGet]
        [Route("GetByCedulaTienda/{cedula}")]
        public IHttpActionResult GetByCedulaTienda(string cedula)
        {
            //[dbo].[RET_ALL_PRODUCTOS_BY_CEDULA_TIENDA_PR]
            apiResp = new ApiResponse();
            var mng = new ProductosManager();
            apiResp.Data = mng.RetrieveAllByCedulaTienda(cedula);
            apiResp.Message = "Successful";
            return Ok(apiResp);
        }

        [HttpGet]
        [Route("GetByNombreCategoria/{nombreCategoria}")]
        public IHttpActionResult GetByNombreCategoria(string nombreCategoria)
        {
            //[dbo].[RET_ALL_PRODUCTOS_BY_NOMBRE_CATEGORIA_PR]
            apiResp = new ApiResponse();
            var mng = new ProductosManager();
            apiResp.Data = mng.RetrieveAllByNombreCategoria(nombreCategoria);
            apiResp.Message = "Successful";
            return Ok(apiResp);
        }

        [HttpGet]
        [Route("GetByNombreProducto/{nombreProducto}")]
        public IHttpActionResult GetByNombreProducto(string nombreProducto)
        {
            //[dbo].[RET_ALL_PRODUCTOS_BY_NOMBRE_PR]
            apiResp = new ApiResponse();
            var mng = new ProductosManager();
            apiResp.Data = mng.RetrieveAllByNombreProducto(nombreProducto);
            apiResp.Message = "Successful";
            return Ok(apiResp);
        }

        [HttpGet]
        [Route("GetByNombreTienda/{nombreTienda}")]
        public IHttpActionResult GetByNombreTienda(string nombreTienda)
        {
            //[dbo].[RET_ALL_PRODUCTOS_BY_NOMBRE_TIENDA_PR]
            apiResp = new ApiResponse();
            var mng = new ProductosManager();
            apiResp.Data = mng.RetrieveAllByNombreTienda(nombreTienda);
            apiResp.Message = "Successful";
            return Ok(apiResp);
        }

        [HttpGet]
        [Route("GetByTagCategoria/{tag}")]
        public IHttpActionResult GetByTagCategoria(string tag)
        {
            //[dbo].[RET_ALL_PRODUCTOS_BY_TAG_CATEGORIA_PR]
            apiResp = new ApiResponse();
            var mng = new ProductosManager();
            apiResp.Data = mng.RetrieveAllByTag(tag);
            apiResp.Message = "Successful";
            return Ok(apiResp);
        }

        [HttpGet]
        [Route("GetByCodigoCategoria/{codigoCategoria}")]
        public IHttpActionResult GetByCodigoCategoria(int codigoCategoria)
        {
            //[dbo].[RET_PRODUCTOS_BY_CATEGORY_CODIGO_PR]
            apiResp = new ApiResponse();
            var mng = new ProductosManager();
            apiResp.Data = mng.RetrieveAllByCodigoCategoria(codigoCategoria);
            apiResp.Message = "Successful";
            return Ok(apiResp);
        }


        [HttpGet]
        [Route("GetByProductType/{tipoProducto}")]
        public IHttpActionResult GetByProductType(string tipoProducto)
        {
            //[dbo].[RET_PRODUCTOS_BY_PRODUCT_TYPE_PR]
            apiResp = new ApiResponse();
            var mng = new ProductosManager();
            apiResp.Data = mng.RetrieveAllByTipoProducto(tipoProducto);
            apiResp.Message = "Successful";
            return Ok(apiResp);
        }


        // POST 
        [HttpPost]
        public IHttpActionResult Post(Productos producto)
        {

            try
            {
                var mng = new ProductosManager();
                mng.Create(producto);

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
        [HttpPut]
        public IHttpActionResult Put(Productos producto)
        {
            try
            {
                var mng = new ProductosManager();
                mng.Update(producto);

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
        [HttpDelete]
        public IHttpActionResult Delete(Productos producto)
        {
            try
            {
                var mng = new ProductosManager();
                mng.Delete(producto);

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
