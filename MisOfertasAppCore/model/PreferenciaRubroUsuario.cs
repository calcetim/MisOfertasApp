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
    public class PreferenciaRubroUsuario : IPreferenciaRubroUsuario
    {
        public PreferenciaRubroUsuario() { }
        public virtual long ID { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Area Area { get; set; }
    }
}
