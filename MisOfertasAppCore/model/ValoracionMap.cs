using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace MisOfertasAppCore.data.model
{
    class ValoracionMap : ClassMap<Valoracion>
    {
        public ValoracionMap()
        {
            Table("VALORACION");
            LazyLoad();
            Id(x => x.ID_VALORACION).GeneratedBy.Identity().Column("ID_VALORACION").GeneratedBy.Sequence("SEQ_USUARIO_ID"); 
            References(x => x.Usuario).Column("USUARIO_ID");
            References(x => x.Producto).Column("PRODUCTO_ID");
            Map(x => x.CALIFICACION).Column("CALIFICACION");
            Map(x => x.NUMERO_VENTA).Column("NUMERO_VENTA");
        }
    }
}
