using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.Interface;
using MisOfertasAppCore.data.model;

namespace MisOfertasAppCore.data.model
{
    public class TipoUsuario
    {
        public TipoUsuario() { }
        public virtual long ID_TIPO_USUARIO { get; set; }
        public virtual string DESCRIPCION { get; set; }
    }
}
