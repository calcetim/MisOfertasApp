using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace MisOfertasAppCore.data.model
{
    class TipoUsuarioMap : ClassMap<TipoUsuario>
    {

        public TipoUsuarioMap()
        {
            Table("TIPO_USUARIO");
            LazyLoad();
            Cache.ReadOnly().IncludeAll();
            Cache.Region("Duracion5H");
            Id(x => x.ID_TIPO_USUARIO).GeneratedBy.Identity().Column("ID_TIPO_USUARIO").GeneratedBy.Sequence("SEQ_TIPO_USUARIO_ID");
            Map(x => x.DESCRIPCION).Not.Nullable().Column("DESCRIPCION");
        }

    }
}
