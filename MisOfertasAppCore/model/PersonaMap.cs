using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace MisOfertasAppCore.data.model
{
    class PersonaMap : ClassMap<Persona>
    {

        public PersonaMap()
        {
            Table("PERSONA");
            LazyLoad();
            Cache.ReadOnly().IncludeAll();
            Cache.Region("Duracion5H");
            Id(x => x.ID_PERSONA).GeneratedBy.Identity().Column("ID_PERSONA").GeneratedBy.Sequence("SEQ_PERSONA_ID"); ;
            Map(x => x.RUT).Not.Nullable().Column("RUT");
            Map(x => x.DV_RUT).Not.Nullable().Column("DV_RUT");
            Map(x => x.PRIMER_NOMBRE).Not.Nullable().Column("PRIMER_NOMBRE");
            Map(x => x.SEGUNDO_NOMBRE).Column("SEGUNDO_NOMBRE");
            Map(x => x.APELLIDO_PATERNO).Not.Nullable().Column("APELLIDO_PATERNO");
            Map(x => x.APELLIDO_MATERNO).Not.Nullable().Column("APELLIDO_MATERNO");
            References(x => x.Comuna).Column("COMUNA_ID");
            Map(x => x.DIRECCION).Not.Nullable().Column("DIRECCION");
            Map(x => x.TELEFONO).Not.Nullable().Column("TELEFONO");
            Map(x => x.IS_ACTIVE).Not.Nullable().Column("IS_ACTIVE");
            Map(x => x.EMAIL).Column("EMAIL");

        }

    }
}
