using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertasAppCore.data.business
{
   public class UsuarioSesionBO
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public string username { get; set; }
        public DateTime fechaSesion { get; set; }
        public string ip { get; set; }
        public string navegador { get; set; }
        public string versionNavegador { get; set; }
        public string centro { get; set; }
        public long tiendaId { get; set; }
        public string tienda { get; set; }
        public bool accesoValido { get; set; }
        public string email { get; set; }
        public DateTime fechaIntentoAcceso { get; set; }
        public DateTime ipIntentoAcceso { get; set; }

    }
}
