using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MisOfertasApp.Models
{
    public class GetWsVentasRealizadas
    {
        public long VENTAS_WS_ID { get; set; }
        public long USUARIO_RUT { get; set; }
    }


    public class GetWsVentasCollection
    {
      public  List<GetWsVentasRealizadas> ListaVentasCollection { get; set; }
    }
}