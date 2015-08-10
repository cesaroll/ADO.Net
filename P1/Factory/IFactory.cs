using System.Collections.Generic;
using System.Linq;
using P1.Enity;

namespace P1.Factory
{
    public interface IFactory<T> where T : IEntity, new() 
    {
        IEnumerable<T> RetrieveAll();
    }
}