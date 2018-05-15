using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cache;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate;
using NHibernate.Cfg;
using NHibernate.Caches.SysCache;
using NHibernate.Tool.hbm2ddl;
using MisOfertasAppCore.data.model;


namespace MisOfertasAppCore
{

    public class SessionFactoryHelper
    {

        static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static ISessionFactory CreateSessionFactory()
        {

            try
            {

                var c = Fluently.Configure();

                c.Database(OracleClientConfiguration.Oracle10
                .ConnectionString(x => x.FromConnectionStringWithKey("ORACLE_FLUENT_CONEXION"))            
                .Driver<NHibernate.Driver.OracleClientDriver>())

                .Mappings(m => m.FluentMappings.Add<RegionMap>())
                .Mappings(m => m.FluentMappings.Add<ComunaMap>())
                .Mappings(m => m.FluentMappings.Add<TiendaMap>())
                .Mappings(m => m.FluentMappings.Add<AreaMap>())
                .Mappings(m => m.FluentMappings.Add<PersonaMap>())
                .Mappings(m => m.FluentMappings.Add<TipoUsuarioMap>())
                .Mappings(m => m.FluentMappings.Add<UsuarioMap>())
                .Mappings(m => m.FluentMappings.Add<OfertaMap>())
                .Mappings(m => m.FluentMappings.Add<ProductoMap>())
                .Mappings(m => m.FluentMappings.Add<PreferenciaTiendaUsuarioMap>())
                .Mappings(m => m.FluentMappings.Add<PreferenciaRubroUsuarioMap>())
                .Mappings(m => m.FluentMappings.Add<WsVentasRealizadasMap>())


                //.Mappings(m =>m.FluentMappings.ExportTo("C:\\MappingsSAJ"))                
                .BuildConfiguration();

                var sessionFactory = c.BuildSessionFactory();

                return sessionFactory;
            }
            catch (Exception error) {


            }

            return null;
        }
    }
}
