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
    public class ProductoDao : Repository<Producto>
    {
        readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IList<IProducto> getProductosQuery()
        {

            try
            {


                var session = this.getSession();


                var productos = session.CreateQuery(@"select C from Producto C")
                                                    .List<IProducto>();

         
                return productos;


            }
            catch (Exception error)
            {

                log.Error("->ERROR DE SISTEMA", error);

            }


            return null;
        }
        



    }
}
