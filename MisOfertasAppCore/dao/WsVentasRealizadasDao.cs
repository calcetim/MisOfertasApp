using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.model;
using MisOfertasAppCore.data;
using NHibernate;
using MisOfertasAppCore.data.repository;
using MisOfertasAppCore.data.Interface;


namespace MisOfertasAppCore.data.dao
{
    public class WsVentasRealizadasDao : Repository<WsVentasRealizadas>
    {
        readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public IList<IWsVentasRealizadas> getWS()
        {

            try
            {


                var session = this.getSession();


                var ws = session.CreateQuery(@"select w from WsVentasRealizadas w")    
                                                    .List<IWsVentasRealizadas>();

                return ws;


            }
            catch (Exception error)
            {

                log.Error("->ERROR DE SISTEMA", error);

            }


            return null;
        }



    }
}
