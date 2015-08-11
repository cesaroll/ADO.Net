using System.Collections.Generic;
using P1.Interface.Entity;

namespace P1.Interface.Factory
{
    public interface IFactory<T> where T : IEntity, new() 
    {
        IEnumerable<T> RetrieveAll();

        T RetrieveByPrimaryKey(object value);

        IEnumerable<T> RetrieveByParameter(IEnumerable<KeyValuePair<string, object>> parms);

        IEnumerable<string> PrintAll(IEnumerable<T> items);
    }
}