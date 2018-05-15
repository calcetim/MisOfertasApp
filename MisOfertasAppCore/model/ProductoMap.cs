using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace MisOfertasAppCore.data.model
{
    class ProductoMap : ClassMap<Producto>
    {

        public ProductoMap()
        {
            Table("PRODUCTO");
            LazyLoad();
            Id(x => x.ID_PRODUCTO).GeneratedBy.Identity().Column("ID_PRODUCTO").GeneratedBy.Sequence("SEQ_PRODUCTO_ID"); ;
            Map(x => x.NOMBRE_PRODUCTO).Not.Nullable().Column("NOMBRE_PRODUCTO");
            Map(x => x.ES_PERECIBLE).Not.Nullable().Column("ES_PERECIBLE");
            Map(x => x.FECHA_VENCIMIENTO).Column("FECHA_VENCIMIENTO");
            Map(x => x.IS_ACTIVE).Column("IS_ACTIVE");
            References(x => x.Area).Column("RUBRO_ID");
            HasMany(x => x.Ofertas).KeyColumn("ID_OFERTA");

        }

    }
}
