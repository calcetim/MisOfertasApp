using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertasAppCore.data.Interface
{
    public interface IImagen
    {
        long ID_IMAGEN { get; set; }
        byte[] IMAGEN { get; set; }
        string NOMBRE_ARCHIVO { get; set; }
        string FORMATO { get; set; }
        string EXTENSION { get; set; }
        byte[] comprimir(byte[] data);
        byte[] descomprimir(byte[] data);

    }
}
