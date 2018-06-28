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
using System.IO;
using Rotativa;
using System.Drawing;
using System.Drawing.Imaging;

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


        [HttpPost]
        public JsonResult editarPublicacion(long oferta_id)
        {



            var ProductoDao = new ProductoDao();
            var producto = ProductoDao.GetReference<IProducto>(oferta_id);

            var ofertas = new { producto.NOMBRE_PRODUCTO, producto.Ofertas.FirstOrDefault().PRECIO  , producto.Ofertas.FirstOrDefault().PRECIO_OFERTA , producto.Ofertas.FirstOrDefault().PCT_DESCUENTO , producto.Ofertas.FirstOrDefault().STOCK , producto.Ofertas.FirstOrDefault().Tienda.ID_TIENDA , producto.ID_PRODUCTO , producto.Ofertas.FirstOrDefault().DETALLE , producto.Ofertas.FirstOrDefault().ID_OFERTA , producto.Ofertas.FirstOrDefault().Imagen.ID_IMAGEN};
            return this.Json(ofertas, JsonRequestBehavior.AllowGet);
        }


        public JsonResult eliminarPublicacion(long oferta_id)
        {



            OfertaDao  objOfertaDao = new OfertaDao();
            bool result = objOfertaDao.elimiarOfertaPorProducto(oferta_id);

            string resultao;

            if (result == true)
            {
                resultao = "OK";
            }
            else {
                resultao = "OK";
            }
            

           // var ofertas = new { producto.NOMBRE_PRODUCTO, producto.Ofertas.FirstOrDefault().PRECIO, producto.Ofertas.FirstOrDefault().PRECIO_OFERTA, producto.Ofertas.FirstOrDefault().PCT_DESCUENTO, producto.Ofertas.FirstOrDefault().STOCK, producto.Ofertas.FirstOrDefault().Tienda.ID_TIENDA, producto.ID_PRODUCTO, producto.Ofertas.FirstOrDefault().DETALLE, producto.Ofertas.FirstOrDefault().ID_OFERTA, producto.Ofertas.FirstOrDefault().Imagen.ID_IMAGEN };
            return this.Json(result, JsonRequestBehavior.AllowGet);
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
        public ActionResult GuardarValoracionProducto(long codigo_venta, long valoracion , long producto_id)
        {
            var usuarioSesion = Session["USUARIO_SESION"] as UsuarioSesionBO;

            ValoracionDao valoracion_dao = new ValoracionDao();
            valoracion_dao.registraValoracion(codigo_venta, valoracion , usuarioSesion.id, producto_id);
            valoracion_dao.Close();

            long someMessage;


            if (codigo_venta > 0)
            {
                someMessage = codigo_venta;
            }
            else
            {
                someMessage = 0;
            }

            TempData["message"] = someMessage;

           return RedirectToAction("OfertaProductoDetalle","Home" , new { id_producto = producto_id , id_venta = codigo_venta });
            
            /*
           var data = new { Url = Url.Action("OfertaProductoDetalle", "Home", new { id_producto = producto_id, id_venta = codigo_venta })};
           return this.Json(data, JsonRequestBehavior.AllowGet);
           */

        }


        public ActionResult OfertaProductoDetalle(long id_producto, long? id_venta)
        {

            /*var OfertaDao = new OfertaDao();
            var oferta = OfertaDao.GetReference<IOferta>(id);
            return View(oferta);*/
            ViewBag.valor_producto = id_producto;




            ViewBag.IdVenta = id_venta;
            ViewBag.Message = TempData["message"];

            var ProductoDao = new ProductoDao();
            var producto = ProductoDao.GetReference<IProducto>(id_producto);


            //NHibernateUtil.Initialize(producto.Ofertas);
            //producto.CODIGO_VENTA_WEB = Convert.ToInt64(TempData["message"]);


            return View("OfertaProductoDetalle", producto);


            //var OfertaDao = new OfertaDao();
            //var ofertas = OfertaDao.getOfertaPorProducto(id);
            //return View(ofertas);

        }


        [HttpPost]
        [AllowCrossSiteJson]
        public JsonResult ValorarProducto(long codigo_venta)
        {

            var usuarioSesion = Session["USUARIO_SESION"] as UsuarioSesionBO;


            ValoracionDao valoracion_dao = new ValoracionDao();
            bool existeValoracion = valoracion_dao.getValoracionPorUsuario(codigo_venta, usuarioSesion.id);

            var data = "";

            //CONSULTAMOS EN BASE DE DATOS SI EXISTE VALORACION PARA LA VENTA DEL PRODUCTO CON USUARIO
            if (existeValoracion == true)
            {

                data = "VALORACION_REALIZADA";
        
                return Json(data, JsonRequestBehavior.AllowGet);

            }
            else
            {
            //SI NO EXISTE VALORACION CON LA VENTA Y USUARIO CONSULTAMOS EL SERVICIO

                using (var webClient = new WebClient())
                {
                    //OBTENER EL STRING DE DATOS
                    String datosJSON = webClient.DownloadString("http://localhost:82/");

                    

                    GetWsVentasCollection lista_ventas = JsonConvert.DeserializeObject<GetWsVentasCollection>(datosJSON);


                    if (lista_ventas.ListaVentasCollection.Where(x => x.VENTAS_WS_ID.Equals(codigo_venta)).Count() > 0)
                    {
                        data = "OK";
                    }
                    else
                    {
                        data = "NO";
                    }

                    //lista_ventas.ListaVentasCollection.Where(x => x.VENTAS_WS_ID.Equals(codigo_venta)).FirstOrDefault();


                    //foreach (var item in lista_ventas.ListaVentasCollection)
                    //{
                    //    if (item.VENTAS_WS_ID == codigo_venta)
                    //    {

                    //        data = "OK";
                    //        break;
                    //    }
                    //    else {

                    //        data = "NO";
                    //    }

                    //}

                    return Json(data, JsonRequestBehavior.AllowGet);
                }

            }

        }




        public ActionResult GenerarCuponPDF(string producto_id, string nombre, string codigo_venta)
        {

            ViewBag.NombreUsuario = nombre;
            ViewBag.CodigoVenta = codigo_venta;

            /*location.href = data.Url;*/

            //var data = new { Status = true, Url = Url.Action("InprimirCuponDescuento", "Home", new { id = id, nombre = nombre, codigo_venta = codigo_venta  })};
            //return this.Json(data, JsonRequestBehavior.AllowGet);

            //return RedirectToAction("InprimirCuponDescuento", "Home", new { id = id, nombre = nombre, codigo_venta = codigo_venta , esVista= 1 });
            return View();

        }

        public ActionResult InprimirCuponDescuento(string producto_id, string codigo_venta) {

            var usuarioSesion = Session["USUARIO_SESION"] as UsuarioSesionBO;
            var q = new ActionAsPdf("GenerarCuponPDF", new { id = producto_id, nombre = usuarioSesion.nombre , codigo_venta = codigo_venta });
            return q;
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


        [HttpPost]
        [AllowCrossSiteJson]
        [AcceptVerbs(HttpVerbs.Post)]
        public FileStreamResult getArchivo(long id)
        {
            ImagenDao doc = new ImagenDao();
            var documento = doc.GetReference<IImagen>(id);

            MemoryStream ms = new MemoryStream(documento.descomprimir(documento.IMAGEN));
            doc.Close();


            return new FileStreamResult(ms, documento.FORMATO) { FileDownloadName = documento.NOMBRE_ARCHIVO };
            //return new FileStreamResult(new FileStream(ms.ToString(), FileMode.Open), documento.FORMATO);
        }


        [HttpGet]
        public FileStreamResult ViewImage(long id)
        {
            ImagenDao doc = new ImagenDao();
            var documento = doc.GetReference<IImagen>(id);

            MemoryStream ms = new MemoryStream(documento.descomprimir(documento.IMAGEN));
            doc.Close();

            return new FileStreamResult(ms, documento.FORMATO);
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GetFile(long id)
        {
            // No need to dispose the stream, MVC does it for you
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "myimage.png");
            FileStream stream = new FileStream(path, FileMode.Open);
            FileStreamResult result = new FileStreamResult(stream, "image/png");
            result.FileDownloadName = "image.png";
            return result;
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