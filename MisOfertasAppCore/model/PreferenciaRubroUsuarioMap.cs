using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace MisOfertasAppCore.data.model
{
    class PreferenciaRubroUsuarioMap : ClassMap<PreferenciaRubroUsuario>
    {

        public PreferenciaRubroUsuarioMap()
        {
            Table("PREF_RUBRO_USUARIO");
            LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID_PREF_RUBRO").GeneratedBy.Sequence("SEQ_PREF_RUBRO_ID"); ;
            References(x => x.Usuario).Column("USUARIO_ID").LazyLoad();
            References(x => x.Area).Column("RUBRO_ID");
            //HasMany(x => x.Tienda).KeyColumn("TIENDA_ID");

        }

    }
}
