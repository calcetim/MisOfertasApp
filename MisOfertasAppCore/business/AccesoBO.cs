using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.repository;
using MisOfertasAppCore.data.model;
using MisOfertasAppCore.data.dao;
using MisOfertasAppCore.data.security;


namespace MisOfertasAppCore.data.business
{
   public class AccesoBO
    {

        readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UsuarioSesionBO AccesoMisOfertas(string username,string password) {

            bool passwordMatch = false;
            UsuarioSesionBO usuarioSesion = new UsuarioSesionBO();
            using (var session = NHibernateSessionManager.Instance.GetSessionFactory().OpenSession())
            {

                try
                {


                    string ip         = System.Web.HttpContext.Current.Request.UserHostAddress;
                    string str_equipo = System.Web.HttpContext.Current.Request.LogonUserIdentity.Name;
                    System.Web.HttpBrowserCapabilities browser = System.Web.HttpContext.Current.Request.Browser;

                    var sec_usuario = session.CreateQuery(@"select u from
                                                                  Usuario u
                                                                  inner join fetch  u.Persona p
                                                                  left  join fetch  u.TipoUsuario rc
                                                                  left  join fetch  u.Tienda  t
                                                                  where u.USERNAME=:username and u.USER_IS_ACTIVE=1")
                                                 .SetString("username", username)
                                                 .List<Usuario>()
                                                 .ElementAt<Usuario>(0);

                    

                    if (sec_usuario != null)
                    {
                        int saltSize = 6;
                        int base64SaltStringLength = ((saltSize + 2) / 3) * 4;
                        string salt = sec_usuario.PASSW.Substring(sec_usuario.PASSW.Length - base64SaltStringLength);

                        SecuritySingleton seguridad  = SecuritySingleton.Instance;
                        string hashedPasswordAndSalt = seguridad.CrearPasswdHashConSal(password, salt);
                        passwordMatch                = hashedPasswordAndSalt.Equals(sec_usuario.PASSW);


                        var segundoApellido = sec_usuario.Persona.APELLIDO_MATERNO == null ? "" : sec_usuario.Persona.APELLIDO_MATERNO.Substring(0, 1);

                        usuarioSesion.id               = sec_usuario.ID_USUARIO;
                        usuarioSesion.nombre           = sec_usuario.Persona.PRIMER_NOMBRE  +" "+ sec_usuario.Persona.APELLIDO_PATERNO + " " + segundoApellido;
                        usuarioSesion.tienda           = sec_usuario.Tienda == null ? "" : sec_usuario.Tienda.NOMBRE;
                        usuarioSesion.email            = sec_usuario.Persona.EMAIL == null ? "" : sec_usuario.Persona.EMAIL;
                        usuarioSesion.tipoUsuario      = sec_usuario.TipoUsuario.ID_TIPO_USUARIO;
                        usuarioSesion.fechaSesion      = DateTime.Now;
                        usuarioSesion.accesoValido     = passwordMatch;
                        usuarioSesion.ip               = ip;
                        usuarioSesion.navegador        = browser.Browser;
                        usuarioSesion.versionNavegador = browser.Version;


                    }

                }
                catch (Exception error) {

                    log.Error("->ERROR DE SISTEMA", error);

                }


            }


            return usuarioSesion;

        }












    }
}
