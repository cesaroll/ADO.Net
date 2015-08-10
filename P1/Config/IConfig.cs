using System.Data;
using P1.Enity;
using P1.Factory;

namespace P1.Config
{
    public interface IConfig<T> where T : IEntity, new()
    {
        string GetSelectAllQuery();

        T GetEntityFromReader(IDataReader dr);

        string PrintableString(T entity);

    }
}