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
   public  class ComunaDao : Repository<IComuna>
    {
        readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IList<IComuna> getComunasPorRegion(long idRegion) {

            try
            {
                

                   var session = this.getSession();
           

                    var comunas = session.CreateQuery(@"select C from Comuna C
                                                        INNER JOIN FETCH C.Region R                          
                                                        where R.ID_REGION=:idRegion")
                                                        .SetInt64("idRegion", idRegion)
                                                        .List<IComuna>();

                    return comunas;
                

            }
            catch (Exception error) {

                log.Error("->ERROR DE SISTEMA", error);

            }


            return null;
        }


    }
}
