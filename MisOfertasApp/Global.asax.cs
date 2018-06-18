using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MisOfertasAppCore;

namespace MisOfertasApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Warn("==================INICIA SERVICIO===================");
            NHibernateSessionManager.Instance.GetSessionFactory();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

			//ViewEngines.Engines.Add(new PdfViewEngine());
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        protected void Application_End()
        {
            log.Warn("==================INICIA TERMINADO===================");
            NHibernateSessionManager.Instance.EndSessionFactory();
        }
    }
}
