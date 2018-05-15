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
    public class WsVentasRealizadas : IWsVentasRealizadas
    {
        public WsVentasRealizadas()
        {

        }

      
        public virtual long VENTAS_WS_ID { get; set; }
        public virtual long USUARIO_RUT { get; set; }
    }
}