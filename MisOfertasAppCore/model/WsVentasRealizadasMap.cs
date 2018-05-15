using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace MisOfertasAppCore.data.model
{
    class WsVentasRealizadasMap : ClassMap<WsVentasRealizadas>
    {

        public WsVentasRealizadasMap()
        {
            Table("WS_VENTAS_REALIZADAS");
            LazyLoad();
            Id(x => x.VENTAS_WS_ID).GeneratedBy.Identity().Column("VENTAS_WS_ID").GeneratedBy.Sequence("SEQ_WS_ID"); ;
            Map(x => x.USUARIO_RUT).Not.Nullable().Column("USUARIO_RUT");
            
            

        }

    }
}
