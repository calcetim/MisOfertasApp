using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MisOfertasApp.Models;
using MisOfertasAppCore.data.business;
using MisOfertasAppCore.data.Interface;
using MisOfertasAppCore.data.model;
using MisOfertasAppCore.data.dao;

using System.Web.Security;
using System.Threading.Tasks;

namespace MisOfertasApp.Controllers
{


    public class HomeController : Controller
    {
        public ActionResult Index(string mensajeLogin)
        {


            ViewBag.Message = mensajeLogin;
            return View();
        }

        public ActionResult MisOfertasProducto()
        {
            
                var OfertaDao = new OfertaDao();
                IList<IOferta> ofertas = OfertaDao.GetAll<IOferta>();
                if (ofertas.Count() > 0)
                {
                    return View(ofertas);
                }
                else {
                    return View();
                }
            
        }

        [HttpPost]
        [AllowCrossSiteJson]
        public JsonResult GuardarUsuario(Usuario usuario)
        {

            UsuarioDao usuariodao = new UsuarioDao();
            usuariodao.registraUsuario(usuario);
            usuariodao.Close();


            return Json(Url.Action("Index", "Home"));
            
        }

        [HttpPost]
        [AllowCrossSiteJson]
        public ActionResult buscarUsuarioPorRut(string rut)
        {
            PersonaDao persona_dao = new PersonaDao();
            bool existeUsuario  =  persona_dao.getPersonasPorRut(rut);

            var data = new
            {
                existeUsuario = existeUsuario
                
            };

            return Json(data, JsonRequestBehavior.AllowGet);
            
        }



        public ActionResult CierreSesion()
        {


            Session.Clear();
            Session.Abandon();


            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                FormsAuthentication.SignOut();
            }

            

            return RedirectToAction("Index", "Home"); ;

        }


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
                string valMensaje = "Usuario u contraseña invalidos";

                return Json(Url.Action("Index", "Home" , new { mensajeLogin = valMensaje }));
            }
        }


        public ActionResult ListadoProductosOfertas()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult OfertaProductoDetalle(long id)
        {


            var ProductoDao = new ProductoDao();
            var producto = ProductoDao.GetReference<IProducto>(id);

     
                return View(producto);
     

        }



        public ActionResult MiCuenta()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}