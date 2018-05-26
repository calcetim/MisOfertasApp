using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.model;

namespace MisOfertasAppCore.data.Interface
{
    public interface IProducto
    {
        long ID_PRODUCTO { get; set; }
        string NOMBRE_PRODUCTO { get; set; }
        Area Area { get; set; }
        long ES_PERECIBLE { get; set; }
        string FECHA_VENCIMIENTO { get; set; }
        string IS_ACTIVE { get; set; }
        IList<Oferta> Ofertas { get; set; }


    }
}
