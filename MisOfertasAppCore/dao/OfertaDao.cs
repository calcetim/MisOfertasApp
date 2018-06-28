using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.model;
using MisOfertasAppCore.data;
using NHibernate;
using MisOfertasAppCore.data.repository;
using MisOfertasAppCore.data.Interface;
using System.Web;
using System.IO;

namespace MisOfertasAppCore.data.dao
{
    public class OfertaDao : Repository<IOferta>
    {
        readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public IList<IOferta> getOfertaPorProducto(long idProducto)
        {

            try
            {


                var session = this.getSession();


                var ofertas = session.CreateQuery(@"select Ofe from Oferta Ofe
                                                        INNER JOIN FETCH Ofe.Producto Pro                          
                                                        where Pro.ID_PRODUCTO=:idProducto")
                                                    .SetInt64("idProducto", idProducto)
                                                    .List<IOferta>();

                return ofertas;


            }
            catch (Exception error)
            {

                log.Error("->ERROR DE SISTEMA", error);

            }


            return null;
        }



        public bool elimiarOfertaPorProducto(long idOferta)
        {
            

            try
            {


                var session = this.getSession();
                session.BeginTransaction();


                Oferta obj_oferta = new Oferta();

                obj_oferta = session.CreateQuery(@"select Ofe from Oferta Ofe             
                                                        where Ofe.ID_OFERTA=:idOferta")
                                                   .SetInt64("idOferta", idOferta).UniqueResult<Oferta>();


                if (obj_oferta != null)
                {
                    session.Delete(obj_oferta);
                    session.Transaction.Commit();
                    return true;

                }
                else {
                    return false;
                }

              






            }
            catch (Exception error)
            {

                log.Error("->ERROR DE SISTEMA", error);

            }

            return false;
        }

        public bool ingresarOfertaImagen(IOferta obj_oferta, out string mensaje, HttpFileCollectionBase archivos)
        {

            try
            {

                using (ISession session = this.getSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        obj_oferta.IS_ACTIVE = "1";

                        foreach (string file in archivos)
                        {
                            var fileContent = archivos[file];
                            if (fileContent != null && fileContent.ContentLength > 0)
                            {
                                var stream = fileContent.InputStream;

                                var nombreArchivo = Path.GetFileName(fileContent.FileName);
                                var extension = Path.GetExtension(fileContent.FileName);

                                byte[] buffer = null;
                                buffer = new byte[stream.Length];
                                stream.Read(buffer, 0, (int)stream.Length);

                                var doc = new Imagen();

                                doc.IMAGEN = doc.comprimir(buffer);
                                doc.NOMBRE_ARCHIVO = nombreArchivo;
                                doc.FORMATO = fileContent.ContentType;
                                doc.EXTENSION = extension;

                                
                                obj_oferta.Imagen = doc;

                            }
                        }

                        session.SaveOrUpdate(obj_oferta);
                        transaction.Commit();

                        mensaje = "Consulta Ingresada";

                    }


                }

                return true;
            }
            catch (System.InvalidOperationException  invalidStateException)
            {
                //var invalidValues = invalidStateException.GetInvalidValues();
                mensaje = "Error de validación";


            }
            catch (Exception error)
            {
                mensaje = "Error al ingresar consulta";
                log.Error("->ERROR DE SISTEMA", error);


            }


            return false;
        }

    }
}