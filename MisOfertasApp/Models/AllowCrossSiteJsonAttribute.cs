using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MisOfertasAppCore.data.dao;

namespace MisOfertasApp.Models
{

    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //AccesoRemotoDao accesoremotoDao = new AccesoRemotoDao();
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
            //filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", accesoremotoDao.getDominios());
            //accesoremotoDao.Close();
            base.OnActionExecuting(filterContext);
        }
    }
}