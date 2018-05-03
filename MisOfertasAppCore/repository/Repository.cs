using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;
using MisOfertasAppCore.data;
using MisOfertasAppCore.data.Interface;

namespace MisOfertasAppCore.data.repository
{
    public class Repository<T> : IRepository<T>, IDisposable
    {
        readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ISession session;

        public Repository()
        {
            var sessionFactory = NHibernateSessionManager.Instance.GetSessionFactory();
            try
            {

                session = sessionFactory.OpenSession();
            }
            catch (Exception error)
            {

                log.Error("->ERROR DE CONEXION", error);

            }

        }


        public ISession getSession()
        {
            return session;
        }

        public void Save(T obj)
        {
            session.Save(obj);
        }


        public void Dispose()
        {
            session.Dispose();
        }



        public int GetSqlCount<T>(string table)
        {
            var sql = String.Format("SELECT Count(*) FROM {0}", table);
            var query = session.CreateSQLQuery(sql);
            var result = query.UniqueResult();
            return Convert.ToInt32(result);
        }


        public int GetSqlMax<T>(string column, string table)
        {
            var sql = String.Format("SELECT max({1}) FROM {0}", table, column);
            var query = session.CreateSQLQuery(sql);
            var result = query.UniqueResult();
            return Convert.ToInt32(result);
        }

        public void SaveOrUpdate(T obj)
        {
            session.SaveOrUpdate(obj);
        }

        public void Close()
        {
            session.Close();
        }

        public void Clear()
        {
            session.Clear();
        }

        public void Disconnect()
        {
            session.Disconnect();
        }


        public void Reconnect()
        {
            session.Reconnect();
        }


        public void Update(T obj)
        {
            session.Update(obj);
        }

        public void Delete(T obj)
        {
            session.Delete(obj);
        }

        public void Delete(string hql)
        {
            session.Delete(hql);
        }


        public T Load<T>(object id)
        {
            return session.Load<T>(id);
        }

        public T GetReference<T>(object id)
        {

            return session.Get<T>(id);

        }



        public IList<T> GetByHQL<T>(string hql)
        {
            dynamic obj;
            if (activarCache)
            {

                obj = session.CreateQuery(hql)
                          .SetCacheable(true)
                          .SetCacheRegion(_cacheRegion)
                          .SetCacheMode(CacheMode.Normal)
                          .SetReadOnly(true)
                          .List<T>();

            }
            else
            {
                obj = session.CreateQuery(hql).List<T>();
            }


            return obj;
        }
        private bool activarCache = false;
        public void setCache(bool activar)
        {
            this.activarCache = activar;
        }

        private string _cacheRegion = "";
        public void setCacheRegion(string cacheregion)
        {
            this._cacheRegion = cacheregion;
        }


        public IList<T> GetBySQL<T>(string sql)
        {
            var obj = session.CreateSQLQuery(sql).List<T>();
            return obj;
        }


        public IList<T> GetByProperty<T>(string property, object value)
        {
            StringBuilder hql = new StringBuilder();
            hql.Append(string.Format("FROM {0} a ", typeof(T).FullName));
            hql.Append(string.Format("WHERE a.{0} = ?", property));
            var obj = session.CreateQuery(hql.ToString())
                .SetParameter(0, value)
                .List<T>();

            return obj;
        }

        public IList<T> GetAll<T>(int pageIndex, int pageSize)
        {
            ICriteria criteria = session.CreateCriteria(typeof(T));
            criteria.SetFirstResult(pageIndex * pageSize);
            if (pageSize > 0)
            {
                //criteria.SetFirstResult(1);
                criteria.SetMaxResults(pageSize);
            }
            return criteria.List<T>();
        }

        public IList<T> GetAll<T>()
        {
            return GetAll<T>(0, 0);
        }

        public IList<T> Find<T>(IList<string> strs)
        {
            IList<ICriterion> objs = new List<ICriterion>();
            foreach (string s in strs)
            {
                ICriterion cr1 = Expression.Sql(s);
                objs.Add(cr1);
            }
            ICriteria criteria = session.CreateCriteria(typeof(T));
            foreach (ICriterion rest in objs)
                session.CreateCriteria(typeof(T)).Add(rest);

            criteria.SetFirstResult(0);
            return criteria.List<T>();
        }

        public void Detach(T item)
        {
            session.Evict(item);
        }

        public void Flush()
        {
            session.Flush();
        }

        public void Commit()
        {
            if (session.Transaction.IsActive)
            {
                session.Transaction.Commit();
            }
        }

        public void Rollback()
        {
            if (session.Transaction.IsActive)
            {
                session.Transaction.Rollback();
                session.Clear();
            }
        }

        public void BeginTransaction()
        {
            Rollback();
            session.BeginTransaction();
        }

        public IList<T> GetAllOrdered<T>(string propertyName, bool ascending)
        {
            Order cr1 = new Order(propertyName, ascending);
            IList<T> objsResult = session.CreateCriteria
                (typeof(T)).AddOrder(cr1).List<T>();
            return objsResult;
        }
    }
}
