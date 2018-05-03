using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace MisOfertasAppCore.data.model
{
    class UsuarioMap : ClassMap<Usuario>
    {

        public UsuarioMap()
        {
            Table("USUARIO");
            LazyLoad();
            Cache.ReadOnly().IncludeAll();
            Cache.Region("Duracion5H");
            Id(x => x.ID_USUARIO).GeneratedBy.Identity().Column("ID_USUARIO").GeneratedBy.Sequence("SEQ_USUARIO_ID"); ;
            Map(x => x.USERNAME).Not.Nullable().Column("USERNAME");
            Map(x => x.PASSW).Not.Nullable().Column("PASSW");
            Map(x => x.PUNTOS_ACUMULADOS).Not.Nullable().Column("PUNTOS_ACUMULADOS");
            Map(x => x.USER_IS_ACTIVE).Not.Nullable().Column("USER_IS_ACTIVE");
            References(x => x.Persona).Column("PERSONA_ID");
            References(x => x.TipoUsuario).Column("TIPO_USUARIO_ID");
            References(x => x.Tienda).Column("TIENDA_ID");

        }

    }
}
