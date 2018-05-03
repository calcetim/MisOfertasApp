using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.Interface;
using MisOfertasAppCore.data.model;

namespace MisOfertasAppCore.data.model
{
    public class Persona
    {
        public Persona() { }
        public virtual long ID_PERSONA { get; set; }
        public virtual string RUT { get; set; }
        public virtual string DV_RUT { get; set; }
        public virtual string PRIMER_NOMBRE { get; set; }
        public virtual string SEGUNDO_NOMBRE { get; set; }
        public virtual string APELLIDO_PATERNO { get; set; }
        public virtual string APELLIDO_MATERNO { get; set; }
        public virtual Comuna Comuna { get; set; }
        public virtual string DIRECCION { get; set; }
        public virtual string TELEFONO { get; set; }
        public virtual long IS_ACTIVE { get; set; }
        public virtual string EMAIL { get; set; }

    }
}
