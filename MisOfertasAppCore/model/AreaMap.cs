using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace MisOfertasAppCore.data.model
{
    class AreaMap : ClassMap<Area>
    {
        public AreaMap()
        {
            Table("RUBRO");
            LazyLoad();
            Cache.ReadOnly().IncludeAll();
            Cache.Region("Duracion5H");
            Id(x => x.ID_RUBRO).GeneratedBy.Identity().Column("ID_RUBRO").GeneratedBy.Sequence("SEQ_RUBRO_ID"); ;
            Map(x => x.NOMBRE_RUBRO).Not.Nullable().Column("NOMBRE_RUBRO");

        }

    }
}
