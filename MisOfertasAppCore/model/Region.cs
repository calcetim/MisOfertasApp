using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.Interface;

namespace MisOfertasAppCore.data.model
{
   public class Region:IRegion
    {

        public virtual long ID_REGION { get; set; }
        public virtual string NOMBRE_REGION { get; set; }


    }
}
