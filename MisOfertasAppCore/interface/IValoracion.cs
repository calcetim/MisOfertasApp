using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.model;

namespace MisOfertasAppCore.data.Interface
{
    public interface IValoracion
    {
        long ID_VALORACION { get; set; }
        Usuario Usuario { get; set; }
        Producto Producto { get; set; }
        long CALIFICACION { get; set; }
        long NUMERO_VENTA { get; set; }
    }
}
