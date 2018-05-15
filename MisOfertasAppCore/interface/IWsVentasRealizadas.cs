using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.model;

namespace MisOfertasAppCore.data.Interface
{
    public interface IWsVentasRealizadas
    {

       

        long VENTAS_WS_ID { get; set; }
        long USUARIO_RUT { get; set; }
        
    }
}
