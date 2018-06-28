using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MisOfertasApp.Models;
using MisOfertasAppCore.data.dao;
using MisOfertasAppCore.data.model;
using MisOfertasAppCore.data.Interface;
using MisOfertasAppCore.data.repository;


namespace MisOfertasAppServicioRest.Controllers
{
    public class RestController : Controller
    {
        // GET: Rest
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [AllowCrossSiteJson]
        public ActionResult getInformacionCliente()
        {


            using (var WsVentasDao = new WsVentasRealizadasDao())
            {

                IList<IWsVentasRealizadas> VentasRealizadas = WsVentasDao.getWS();

                var resultado = new
                {
                    ListaVentasCollection = VentasRealizadas
                };



                return Json(resultado, JsonRequestBehavior.AllowGet);
            }


        }
    }

}