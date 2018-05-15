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
            Id(x => x.ID_USUARIO).GeneratedBy.Identity().Column("ID_USUARIO").GeneratedBy.Sequence("SEQ_USUARIO_ID"); ;
            Map(x => x.USERNAME).Not.Nullable().Column("USERNAME");
            Map(x => x.PASSW).Not.Nullable().Column("PASSW");
            Map(x => x.PUNTOS_ACUMULADOS).Column("PUNTOS_ACUMULADOS");
            Map(x => x.USER_IS_ACTIVE).Column("USER_IS_ACTIVE").Default("1");
            Map(x => x.RECIBIR_INFORMACION).Column("RECIBIR_INFORMACION").Default("0");
            References(x => x.Persona).Column("PERSONA_ID").Cascade.SaveUpdate();
            References(x => x.TipoUsuario).Column("TIPO_USUARIO_ID");
            References(x => x.Tienda).Column("TIENDA_ID");
            HasMany(x => x.PreferenciaRubroUsuario).KeyColumn("USUARIO_ID").Cascade.SaveUpdate();
            HasMany(x => x.PreferenciaTiendaUsuario).KeyColumn("USUARIO_ID").Cascade.SaveUpdate();
           
            //HasMany(x => x.PreferenciaTiendaUsuario).KeyColumn("TIENDA_ID").Inverse().Cascade.SaveUpdate().ForeignKeyConstraintName("FK_PRE_TIENDA_USUARIO");
            //.ForeignKeyConstraintName("FK_ReportClient_ParentId");

        }

    }
}
