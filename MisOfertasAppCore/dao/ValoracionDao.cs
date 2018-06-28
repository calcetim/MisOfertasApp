using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.repository;
using MisOfertasAppCore.data.model;
using MisOfertasAppCore.data.Interface;
using MisOfertasAppCore.data.security;
using MisOfertasAppCore.data.business;


namespace MisOfertasAppCore.data.dao
{
    public class ValoracionDao : Repository<IValoracion>
    {
        readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool registraValoracion(long? codigo_venta, long? valoracion, long? usuario_id , long? producto_id)
        {
            

            try
            {
                IValoracion ObjValoracion = new Valoracion();

                ObjValoracion.CALIFICACION = valoracion.GetValueOrDefault();
                ObjValoracion.NUMERO_VENTA = codigo_venta.GetValueOrDefault();
                ObjValoracion.Producto = new Producto { ID_PRODUCTO = producto_id.GetValueOrDefault() };
                ObjValoracion.Usuario = new Usuario { ID_USUARIO = usuario_id.GetValueOrDefault() };

                this.BeginTransaction();
                this.Save(ObjValoracion);
                this.Commit();

                return true;
            }
            catch (Exception error)
            {
                log.Error("->ERROR DE SISTEMA", error);
                this.Rollback();
            }

            finally
            {


            }


            return false;
        }


        public bool getValoracionPorUsuario(long codigo_venta , long usuario_id)
        {

            try
            {
                var session = this.getSession();

                var valoraciones = session.CreateQuery(@"select v from Valoracion v

                                                        where v.Usuario=:usuario_id and v.NUMERO_VENTA=:codigo_venta")
                                                    .SetInt64("codigo_venta", codigo_venta)
                                                    .SetInt64("usuario_id", usuario_id)
                                                    .List<IValoracion>();

                if (valoraciones.Count() > 0)
                {

                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception error)
            {

                log.Error("->ERROR DE SISTEMA", error);

            }


            return false;
        }





        //this.hclave = SecuritySingleton.Instance.CrearPasswdHashConSal(value);




    }
}
