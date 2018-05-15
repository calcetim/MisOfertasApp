using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.model;

namespace MisOfertasAppCore.data.Interface
{
    public interface IUsuario
    {
        long ID_USUARIO { get; set; }
        string USERNAME { get; set; }
        Persona Persona { get; set; }
        TipoUsuario TipoUsuario { get; set; }
        Tienda Tienda { get; set; }
        string PASSW { get; set; }
        string PUNTOS_ACUMULADOS { get; set; }
        long USER_IS_ACTIVE
        {
            get; set;
        }
        long RECIBIR_INFORMACION { get; set; }
        IList<PreferenciaTiendaUsuario> PreferenciaTiendaUsuario { get; set; }
        IList<PreferenciaRubroUsuario> PreferenciaRubroUsuario { get; set; }
    }
}
