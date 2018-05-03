using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.Interface;

namespace MisOfertasAppCore.data.model
{
    public class Area : IArea
    {

        public virtual long ID_RUBRO { get; set; }
        public virtual string NOMBRE_RUBRO { get; set; }


    }
}
