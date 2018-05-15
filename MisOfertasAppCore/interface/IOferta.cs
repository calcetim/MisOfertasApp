﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.model;

namespace MisOfertasAppCore.data.Interface
{
    public interface IOferta
    {

        long ID_OFERTA { get; set; }
        Producto Producto { get; set; }
        long PCT_DESCUENTO { get; set; }
        Tienda Tienda { get; set; }
        string STOCK { get; set; }
        string PRECIO { get; set; }
        string DOS_POR_UNO { get; set; }
        string IS_ACTIVE { get; set; }
        string IMAGEN_ID { get; set; }

    }
}
