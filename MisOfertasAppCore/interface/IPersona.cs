using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.model;

namespace MisOfertasAppCore.data.Interface
{
    public interface IPersona
    {
        long ID_PERSONA { get; set; }
         string RUT { get; set; }
         string DV_RUT { get; set; }
         string PRIMER_NOMBRE { get; set; }
         string SEGUNDO_NOMBRE { get; set; }
         string APELLIDO_PATERNO { get; set; }
         string APELLIDO_MATERNO { get; set; }
         Comuna Comuna { get; set; }
         string DIRECCION { get; set; }
         string TELEFONO { get; set; }
         long IS_ACTIVE { get; set; }
         string EMAIL { get; set; }
    }
}
