using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace MisOfertasAppCore.data.model
{
    class RegionMap : ClassMap<Region>
    {
        public RegionMap()
        {
            Table("REGION");
            LazyLoad();
            Cache.ReadOnly().IncludeAll();
            Cache.Region("Duracion5H");
            Id(x => x.ID_REGION).GeneratedBy.Identity().Column("ID_REGION").GeneratedBy.Sequence("SEQ_REGION_ID"); ;
            Map(x => x.NOMBRE_REGION).Not.Nullable().Column("NOMBRE_REGION");
    
        }

    }
}
