using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.Interface;

namespace MisOfertasAppCore.data.model
{
    public class Imagen : IImagen
    {

        public virtual long ID_IMAGEN { get; set; }
        public virtual byte[] IMAGEN { get; set; }
        public virtual string NOMBRE_ARCHIVO { get; set; }
        public virtual string FORMATO { get; set; }
        public virtual string EXTENSION { get; set; }
        public virtual Oferta Oferta { get; set; }

        public virtual byte[] comprimir(byte[] data)
        {
            using (var compressedStream = new MemoryStream())
            using (var zipStream = new GZipStream(compressedStream, CompressionLevel.Fastest))
            {
                zipStream.Write(data, 0, data.Length);
                zipStream.Close();
                return compressedStream.ToArray();
            }
        }


        public virtual byte[] descomprimir(byte[] data)
        {
            using (var compressedStream = new MemoryStream(data))
            using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
            using (var resultStream = new MemoryStream())
            {
                zipStream.CopyTo(resultStream);
                return resultStream.ToArray();
            }
        }


    }
}
