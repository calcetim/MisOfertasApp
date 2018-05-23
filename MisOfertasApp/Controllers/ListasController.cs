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

        public class SelectOption
        {
            public long ID_PRODUCTO { get; set; }

            public String NOMBRE_PRODUCTO { get; set; }

            public SelectOption()
            {
            }

            public SelectOption(String NOMBRE_PRODUCTO, long ID_PRODUCTO)
            {
                this.NOMBRE_PRODUCTO = NOMBRE_PRODUCTO;
                this.ID_PRODUCTO = ID_PRODUCTO;
            }
        }

        [HttpGet]
        [AllowCrossSiteJson]
        public ActionResult getProductos()
        {


            using (var productoDao = new ProductoDao())
            {

                IList<Producto> productos = productoDao.GetAll<Producto>();
                List<SelectOption> ListaProductosPersonalizada = new List<SelectOption>();

                foreach (Producto producto in productos)
                {
                    ListaProductosPersonalizada.Add(new SelectOption(producto.NOMBRE_PRODUCTO, producto.ID_PRODUCTO));
                }

                productoDao.Close();

                return Json(ListaProductosPersonalizada, JsonRequestBehavior.AllowGet);
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