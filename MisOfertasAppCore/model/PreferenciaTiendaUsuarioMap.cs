using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace MisOfertasAppCore.data.model
{
    class PreferenciaTiendaUsuarioMap : ClassMap<PreferenciaTiendaUsuario>
    {

        public PreferenciaTiendaUsuarioMap()
        {
            Table("PREF_TIENDA_USUARIO");
            LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID_PREF_TIENDA").GeneratedBy.Sequence("SEQ_PREF_TIENDA_ID"); ;
            References(x => x.Usuario).Column("USUARIO_ID").LazyLoad();
            References(x => x.Tienda).Column("TIENDA_ID");
            //HasMany(x => x.Tienda).KeyColumn("TIENDA_ID");

        }

    }
}
