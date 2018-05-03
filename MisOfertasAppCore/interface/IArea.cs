using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertasAppCore.data.Interface
{
    public interface IArea
    {
        long ID_RUBRO { get; set; }
        string NOMBRE_RUBRO { get; set; }
    }
}
