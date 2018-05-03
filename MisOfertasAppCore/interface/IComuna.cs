using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.model;

namespace MisOfertasAppCore.data.Interface
{
    public interface IComuna
    {


        int ID_COMUNA { get; set; }
        string NOMBRE_COMUNA { get; set; }
        Region Region { get; set; }

    }
}
