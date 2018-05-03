using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace MisOfertasAppCore.data.model
{
    class ComunaMap : ClassMap<Comuna>
    {

        public ComunaMap()
        {
            Table("COMUNA");
            LazyLoad();
            Cache.ReadOnly().IncludeAll();
            Cache.Region("Duracion5H");
            Id(x => x.ID_COMUNA).GeneratedBy.Identity().Column("ID_COMUNA").GeneratedBy.Sequence("SEQ_COMUNA_ID"); ;
            Map(x => x.NOMBRE_COMUNA).Not.Nullable().Column("NOMBRE_COMUNA");
            References(x => x.Region).Column("REGION_ID");
  
        }

    }
}
