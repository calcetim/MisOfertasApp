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
    public class Usuario : IUsuario
    {
        public Usuario()
        {
        }


        public virtual long ID_USUARIO { get; set; }
        public virtual string USERNAME { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
        public virtual Tienda Tienda { get; set; }
        public virtual Area Area { get; set; }
        public virtual string PASSW
        {
            get; set;

        }

        public virtual string PUNTOS_ACUMULADOS { get; set; }
        public virtual long USER_IS_ACTIVE { get; set; }
        public virtual long RECIBIR_INFORMACION { get; set; }
        public virtual IList<PreferenciaTiendaUsuario> PreferenciaTiendaUsuario { get; set; }
        public virtual IList<PreferenciaRubroUsuario> PreferenciaRubroUsuario { get; set; }

    }
}
