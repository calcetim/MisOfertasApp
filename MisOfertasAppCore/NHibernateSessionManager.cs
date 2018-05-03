using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cache;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate;
using System.Configuration;
using System.Reflection;




namespace MisOfertasAppCore
{
   public class NHibernateSessionManager
    {
        readonly log4net.ILog  log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly       ISessionFactory _sessionFactory;
        public static readonly NHibernateSessionManager Instance = new NHibernateSessionManager();

        private NHibernateSessionManager()
        {
            try
            {
                if (this._sessionFactory == null)
                {
                    _sessionFactory  = SessionFactoryHelper.CreateSessionFactory();
                }
                else {

                    if (_sessionFactory.IsClosed)
                    {
                     _sessionFactory = SessionFactoryHelper.CreateSessionFactory();
                    }
                }
            }
            catch (Exception error)
            {
                log.Error("->ERROR DE SISTEMA", error);
            }
        }

        public ISessionFactory GetSessionFactory()
        {
          
            return _sessionFactory;
        }




        public ISession GetCurrentSessionContext()
        {
           

            ISession session = null;

            if (NHibernate.Context.CurrentSessionContext.HasBind(_sessionFactory))
            {
                session = _sessionFactory.GetCurrentSession();
            }
            else
            {
                session = _sessionFactory.OpenSession();
                NHibernate.Context.CurrentSessionContext.Bind(session);
            }

            return session;
        }



        public int ClearCache()
        {
            try
            {

                this._sessionFactory.EvictQueries();
                foreach (var collectionMetadata in this._sessionFactory.GetAllCollectionMetadata())
                    this._sessionFactory.EvictCollection(collectionMetadata.Key);
                foreach (var classMetadata in this._sessionFactory.GetAllClassMetadata())
                    this._sessionFactory.EvictEntity(classMetadata.Key);


                return 1;
            }
            catch (Exception error)
            {
                log.Error("->ERROR DE SISTEMA", error);
                
            }
            return 0;
        }


        public ISession UnBindCurrentSessionContext()
        {
            ISession session = null;
            if (_sessionFactory != null)
            {
                if (!_sessionFactory.IsClosed)
                {

                 session= NHibernate.Context.CurrentSessionContext.Unbind(_sessionFactory);
                }
            }


            return session;
        }





        public bool EndSessionFactory()
        {

            try
            {
                if (this._sessionFactory!=null)
                {
                    if (!this._sessionFactory.IsClosed)
                    {
                        _sessionFactory.Close();
                        log.Warn("**********Session Factory End*********");
                    }
                
                }
              
            }
            catch (Exception error)
            {
                log.Error("->ERROR DE SISTEMA", error);
                return false;
            }


            return true;
        }
    }
}
