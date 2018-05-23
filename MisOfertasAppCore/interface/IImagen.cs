using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertasAppCore.data.Interface
{
    public interface IImagen
    {
        long ID_IMAGEN { get; set; }
        byte[] IMAGEN { get; set; }
    }
}
