using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.Interface;
using MisOfertasAppCore.data.model;
using MisOfertasAppCore.data.security;

namespace MisOfertasAppCore.data.model
{
    
    public class Producto : IProducto
    {
        public Producto()
        {
        }

        public virtual long ID_PRODUCTO { get; set; }
        public virtual string NOMBRE_PRODUCTO { get; set; }
        public virtual Area Area { get; set; }
        public virtual long ES_PERECIBLE { get; set; }
        public virtual string FECHA_VENCIMIENTO { get; set; }
        public virtual string IS_ACTIVE { get; set; }

        public virtual IList<Oferta> Ofertas { get; set; }

    }
}
