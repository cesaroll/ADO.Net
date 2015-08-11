using System.Data;
using P1.Enity;
using P1.Factory;

namespace P1.Config
{
    public interface IConfig<T> where T : IEntity, new()
    {
        string SelectAllQuery { get; }

        string PrimaryKey { get; }

        T EntityFromReader(IDataReader dr);

        string PrintableString(T entity);

    }
}