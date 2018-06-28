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
    public class Valoracion : IValoracion
    {
        public Valoracion()
        {
        }


        public virtual long ID_VALORACION { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual long CALIFICACION { get; set; }
        public virtual long NUMERO_VENTA { get; set; }


    }
}
