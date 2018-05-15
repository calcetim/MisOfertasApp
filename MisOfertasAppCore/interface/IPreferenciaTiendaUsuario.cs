using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.model;

namespace MisOfertasAppCore.data.Interface
{
    public interface IPreferenciaTiendaUsuario
    {
        long ID { get; set; }
        Usuario Usuario { get; set; }
        Tienda Tienda { get; set; }
    }
}
