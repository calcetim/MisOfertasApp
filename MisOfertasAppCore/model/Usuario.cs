using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.Interface;
using MisOfertasAppCore.data.model;

namespace MisOfertasAppCore.data.model
{
    public class Usuario 
    {
        public Usuario() { }

        public virtual long ID_USUARIO { get; set; }
        public virtual string USERNAME { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
        public virtual Tienda Tienda { get; set; }
        public virtual string PASSW { get; set; }
        public virtual string PUNTOS_ACUMULADOS { get; set; }
        public virtual long USER_IS_ACTIVE { get; set; }

    }
}
