using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Security;

namespace WebApp.Controllers
{
    [SecurityFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult vCustomers()
        {
            
            return View();
        }

        

        public ActionResult eCustomers()
        {
            return View();
        }

        public ActionResult vTienda()
        {
            return View();
        }

        public ActionResult vListarTienda()
        {
            return View();
        }

        public ActionResult vRegistrarDistribuidor()
        {
            return View();
        }

        public ActionResult vRegistrarInventario()
        {
            return View();
        }

        public ActionResult vLogin()
        {
            return View();
        }
        public ActionResult vRegistrarUsuario()
        {
            return View();
        }

        public ActionResult vAdministrarUsuario()
        {
            return View();
        }

        public ActionResult vEmpleados()
        {
            return View();
        }

        public ActionResult vCategoria()
        {
            return View();
        }

        public ActionResult vProducto()
        {
            return View();
        }

        public ActionResult vRegistrarTiendaDistribuidor()
        {
            return View();
        }
        public ActionResult vPerfilConfiguracion()
        {
            return View();
        }

        public ActionResult vRegistrarTiendaCategorias()
        {
            return View();
        }

        public ActionResult vModificarDistribuidor()
        {
            return View();
        }
    }
}