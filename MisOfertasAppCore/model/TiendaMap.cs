using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace MisOfertasAppCore.data.model
{
    class TiendaMap : ClassMap<Tienda>
    {
        public TiendaMap()
        {
            Table("TIENDA");
            LazyLoad();
            Id(x => x.ID_TIENDA).GeneratedBy.Identity().Column("ID_TIENDA").GeneratedBy.Sequence("SEQ_TIENDA_ID"); ;
            Map(x => x.NOMBRE).Not.Nullable().Column("NOMBRE");

        }

    }
}
