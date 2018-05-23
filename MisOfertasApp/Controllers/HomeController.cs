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
using NHibernate;
using Newtonsoft.Json;
using System.Net;

namespace MisOfertasApp.Controllers
{
   

    public class HomeController : Controller
    {
        readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ActionResult Index(string mensajeLogin)
        {


            ViewBag.Message = mensajeLogin;
            return View();
        }

        /*OBTIENE LAS ULTIMAS OFERTAS PARA LA PATALLA HOME DEL USUARIO*/
        public ActionResult MisOfertasProducto()
        {

            var OfertaDao = new OfertaDao();
            IList<IOferta> ofertas = OfertaDao.GetAll<IOferta>();
            if (ofertas.Count() > 0)
            {
                return View(ofertas);
            }
            else
            {
                return View();
            }

        }

        /*GUARDA USUARIO*/
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
        public async Task<JsonResult> GuardarOferta()
        {

            dynamic resultado;
            string mensaje;
            try
            {

                OfertaDao ofertaDao = new OfertaDao();
      

                var jsonData = Request.Form["jsonData"];
                var consulta = JsonConvert.DeserializeObject<Oferta>(jsonData);

                HttpFileCollectionBase archivos = Request.Files;
                ofertaDao.ingresarOfertaImagen(consulta, out mensaje, archivos);

            }
            catch (Exception error)
            {
                log.Error("->ERROR DE SISTEMA", error);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

                resultado = new
                {
                    codigo = "ERROR",
                    msg = "Error al intentar subir archivo."
                };

                return Json(resultado);
            }

            resultado = new
            {
                codigo = "OK",
                msg = mensaje
            };


            return Json(resultado);
        }



        /*VALIDA QUE NO EXISTA UN SUSUARIO CON EL MISMO RUT*/
        [HttpPost]
        [AllowCrossSiteJson]
        public ActionResult buscarUsuarioPorRut(string rut)
        {
            PersonaDao persona_dao = new PersonaDao();
            bool existeUsuario = persona_dao.getPersonasPorRut(rut);

            var data = new
            {
                existeUsuario = existeUsuario

            };

            return Json(data, JsonRequestBehavior.AllowGet);

        }


        /*CIERRA SESION EN NAVEGADOR*/
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


        /*INICIO SESION VALIDACION*/
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

                return Json(Url.Action("Index", "Home", new { mensajeLogin = valMensaje }));
            }
        }


        public ActionResult ListadoProductosOfertas()
        {
            var OfertaDao = new OfertaDao();
            IList<IOferta> ofertas = OfertaDao.GetAll<IOferta>();
            if (ofertas.Count() > 0)
            {
                return View(ofertas);
            }
            else
            {
                return View();
            }
        }

        public ActionResult OfertaProductoDetalle(long id)
        {

            /*var OfertaDao = new OfertaDao();
            var oferta = OfertaDao.GetReference<IOferta>(id);
            return View(oferta);*/


            var ProductoDao = new ProductoDao();
            var producto = ProductoDao.GetReference<IProducto>(id);
           // NHibernateUtil.Initialize(producto.Ofertas);
            return View(producto);

            //var OfertaDao = new OfertaDao();
            //var ofertas = OfertaDao.getOfertaPorProducto(id);
            //return View(ofertas);

        }



        public ActionResult MiCuenta()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PublicarOfertas()
        {

            var OfertaDao = new OfertaDao();
            IList<IOferta> ofertas = OfertaDao.GetAll<IOferta>();
            if (ofertas.Count() > 0)
            {
                return View(ofertas);
            }
            else
            {
                return View();
            }
        }


    }
}