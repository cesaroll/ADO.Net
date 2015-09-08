using System.Collections.Generic;
using Base.Interface.Entity;

namespace Base.Interface.Factory
{
    public interface IFactory<T> where T : IEntity, new() 
    {
        IEnumerable<T> RetrieveAll();

        T RetrieveByPrimaryKey(object value);

        IEnumerable<T> RetrieveByParameter(IEnumerable<KeyValuePair<string, object>> parms);

        bool InsertNew(T entity);

        IEnumerable<string> PrintAll(IEnumerable<T> items);
    }
}