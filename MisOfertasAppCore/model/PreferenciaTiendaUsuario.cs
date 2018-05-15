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
    public class PreferenciaTiendaUsuario : IPreferenciaTiendaUsuario
    {
        public PreferenciaTiendaUsuario() { }
        public virtual long ID { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Tienda Tienda { get; set; }
    }
}
