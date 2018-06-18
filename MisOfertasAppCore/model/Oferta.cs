using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.Interface;
using MisOfertasAppCore.data.model;
using MisOfertasAppCore.data.security;

namespace MisOfertasAppCore.data.model
{
    public class Oferta : IOferta
    {
        public Oferta()
        {
        }

        public virtual long ID_OFERTA { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual long PCT_DESCUENTO { get; set; }
        public virtual Tienda Tienda { get; set; }
        public virtual string STOCK { get; set; }
        public virtual long PRECIO { get; set; }
        public virtual long PRECIO_OFERTA { get; set; }
        public virtual string DOS_POR_UNO { get; set; }
        public virtual string IS_ACTIVE { get; set; }
        public virtual string DETALLE { get; set; }
        public virtual Imagen Imagen { get; set; }
        /*public virtual IList<Producto> Productos { get; set; }*/

    }
}
