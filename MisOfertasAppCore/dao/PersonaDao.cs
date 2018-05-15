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
    public class PersonaDao : Repository<IPersona>
    {
        readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool getPersonasPorRut(string rut)
        {

            try
            {
                var session = this.getSession();

                var comunas = session.CreateQuery(@"select p from Persona p
                                                        where p.RUT=:rut")
                                                    .SetString("rut", rut)
                                                    .List<IPersona>();

                if (comunas.Count() > 0)
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

    }
}
