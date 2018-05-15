using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertasAppCore.data.repository
{
    public interface IRepository<T>
    {
        void Save(T obj);
        void Close();
        void Update(T obj);
        void Delete(T obj);
        void Delete(string hql);
        T Load<T>(object id);

        Task<T> LoadAsync<T>(object id);

        T GetReference<T>(object id);

        Task<T> GetReferenceAsync<T>(object id);

        IList<T> GetByProperty<T>(string property, object value);
        IList<T> GetByHQL<T>(string hql);
        IList<T> GetAll<T>();

        Task<IList<T>> GetAllAsync<T>();

        IList<T> GetAllOrdered<T>(string propertyName, bool Ascending);
        IList<T> Find<T>(IList<string> criteria);
        void Detach(T item);
        IList<T> GetAll<T>(int pageIndex, int pageSize);
        void Commit();
        void Rollback();
        void BeginTransaction();
        void SaveOrUpdate(T obj);
        void setCacheRegion(string cacheregion);
        void setCache(bool activar);


    }
}
