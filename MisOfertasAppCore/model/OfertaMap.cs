using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace MisOfertasAppCore.data.model
{
    class OfertaMap : ClassMap<Oferta>
    {

        public OfertaMap()
        {
            Table("OFERTA");
            LazyLoad();
            Id(x => x.ID_OFERTA).GeneratedBy.Identity().Column("ID_OFERTA").GeneratedBy.Sequence("SEQ_OFERTA_ID"); ;
            Map(x => x.PCT_DESCUENTO).Not.Nullable().Column("PCT_DESCUENTO");
            Map(x => x.STOCK).Not.Nullable().Column("STOCK");
            Map(x => x.PRECIO).Column("PRECIO");
            Map(x => x.IS_ACTIVE).Column("IS_ACTIVE");
            Map(x => x.IMAGEN_ID).Column("IMAGEN_ID");
            References(x => x.Tienda).Column("TIENDA_ID");
            References(x => x.Producto).Column("PRODUCTO_ID");



        }

    }
}
