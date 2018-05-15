using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.repository;
using MisOfertasAppCore.data.model;
using MisOfertasAppCore.data.Interface;
using MisOfertasAppCore.data.security;


namespace MisOfertasAppCore.data.dao
{
    public class UsuarioDao : Repository <IUsuario>
    {
        readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool registraUsuario(IUsuario usuario)
        {

            try
            {
                usuario.PASSW = SecuritySingleton.Instance.CrearPasswdHashConSal(usuario.PASSW);
                usuario.USER_IS_ACTIVE = 1;
                this.BeginTransaction();
                this.Save(usuario);
                this.Commit();

                return true;
            }
            catch (Exception error)
            {
                log.Error("->ERROR DE SISTEMA", error);
                this.Rollback();
            }

            finally {

                
            }


            return false;
        }


        //this.hclave = SecuritySingleton.Instance.CrearPasswdHashConSal(value);




    }
}
