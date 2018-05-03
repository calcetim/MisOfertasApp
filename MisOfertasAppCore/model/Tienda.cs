using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.Interface;

namespace MisOfertasAppCore.data.model
{
    public class Tienda:ITienda
    {

        public virtual long ID_TIENDA { get; set; }
        public virtual string NOMBRE { get; set; }
    }
}
