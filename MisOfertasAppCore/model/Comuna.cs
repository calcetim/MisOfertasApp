using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.Interface;

namespace MisOfertasAppCore.data.model
{
   public class Comuna :IComuna
    {

        public virtual int ID_COMUNA { get; set; }
        public virtual string NOMBRE_COMUNA { get; set; }
        public virtual Region Region { get; set; }


    }
}
