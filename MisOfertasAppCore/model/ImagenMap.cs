using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace MisOfertasAppCore.data.model
{
    class ImagenMap : ClassMap<Imagen>
    {
        public ImagenMap()
        {
            Table("IMAGEN_OFERTA");
            LazyLoad();
            Id(x => x.ID_IMAGEN).GeneratedBy.Identity().Column("ID_IMAGEN").GeneratedBy.Sequence("SEQ_IMAGEN_ID"); ;
            Map(x => x.IMAGEN).Not.Nullable().Column("IMAGEN");
            Map(x => x.NOMBRE_ARCHIVO).Column("NOMBRE_ARCHIVO");
            Map(x => x.EXTENSION).Column("EXTENSION");
            Map(x => x.FORMATO).Column("FORMATO");
            References(x => x.Oferta).Column("IMAGEN_ID").Not.LazyLoad();
        }

    }
}
