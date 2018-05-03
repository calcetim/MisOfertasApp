using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MisOfertasApp.Models;
using MisOfertasAppCore.data.dao;
using MisOfertasAppCore.data.model;
using MisOfertasAppCore.data.Interface;

namespace MisOfertasApp.Controllers
{
    public class ListasController : Controller
    {
        // GET: Listas
        // GET: Comuna
        [HttpGet]
        [AllowCrossSiteJson]
        public JsonResult getComunasPorRegion(long regionId)
        {


            using (var comunaDao = new ComunaDao())
            {
                IList<IComuna> comunas = comunaDao.getComunasPorRegion(regionId);
                return Json(comunas, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        [AllowCrossSiteJson]
        public ActionResult getRegiones()
        {


            using (var regionDao = new RegionDao())
            {

                IList<Region> regiones = regionDao.GetAll<Region>();

                return Json(regiones, JsonRequestBehavior.AllowGet);
            }


        }

        [HttpGet]
        [AllowCrossSiteJson]
        public ActionResult getTiendas()
        {


            using (var tiendaDao = new TiendaDao())
            {

                IList<Tienda> tiendas = tiendaDao.GetAll<Tienda>();

                return Json(tiendas, JsonRequestBehavior.AllowGet);
            }


        }


        [HttpGet]
        [AllowCrossSiteJson]
        public ActionResult getAreasInteres()
        {


            using (var AreaDao = new AreaDao())
            {

                IList<Area> tiendas = AreaDao.GetAll<Area>();

                return Json(tiendas, JsonRequestBehavior.AllowGet);
            }


        }

    }
}