using System.Collections.Generic;

namespace BusDep.IDataAccess
{
    public interface IBaseDA<T>
    {
        T GetById<TId>(TId id);
        void Save(T obje);
        void Delete(T obje);
        IList<T> GetAll();
        IList<T> GetAll(string orderByProperty, bool ascendente);
        IList<T> SearchBy(IList<KeyValuePair<string, object>> param);
        IList<T> SearchBy(IList<KeyValuePair<string, object>> param, string orderByProperty, bool ascendente);
        IList<T> SearchLike(IList<KeyValuePair<string, object>> param);
        IList<T> SearchLike(IList<KeyValuePair<string, object>> param, string orderByProperty, bool ascendente);

    }
}