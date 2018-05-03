using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertasAppCore.data.repository;
using MisOfertasAppCore.data.model;
using MisOfertasAppCore.data.security;
using System.Text.RegularExpressions;

namespace MisOfertasAppCore.data.saj.dao
{
   public  class SEC_USUARIO_DAO : Repository<Usuario>
    {
        /// <summary>  
        ///  Obtiene el usuario según username y clave SAJ.
        /// </summary> 

        public Usuario getUsuarioPorUseName(string username) {
                   

          var usuario = this.GetByProperty<Usuario>("USERNAME", username).FirstOrDefault<Usuario>();
       


          return usuario;

        }


      

 

    }
}
