using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MisOfertasApp.Models;
using MisOfertasAppCore.data.business;
using System.Web.Security;

namespace MisOfertasApp.Controllers
{


    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MisOfertasProducto()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        //public Action CierreSesion()
        //{


        //    Session.Clear();
        //    Session.Abandon();


        //    if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        //    {

        //        FormsAuthentication.SignOut();
        //    }

        //    RedirectToAction("Index", "Home");

        //    return null;

        //}

        [HttpPost]
        [AllowCrossSiteJson]
        public ActionResult Login(string usuario, string clave)
        {
            AccesoBO accesoBO = new AccesoBO();

            UsuarioSesionBO usuarioSesion = accesoBO.AccesoMisOfertas(usuario, clave);

            if (usuarioSesion.accesoValido)
            { 
       
                Session["USUARIO_SESION"] = usuarioSesion;

                FormsAuthentication.SetAuthCookie(usuarioSesion.username, true);

                return Json(Url.Action("MisOfertasProducto", "Home"));
            }
            else
            {
                ViewBag.Message = "Your application description page.";

                return Json(Url.Action("Index", "Home"));
            }
        }


        public ActionResult Product()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}