using System.Data;
using Base.Interface.Entity;

namespace Base.Interface.Config
{
    public interface IConfig<T> where T : IEntity, new()
    {
        string SelectAllQuery { get; }

        string PrimaryKey { get; }

        T EntityFromReader(IDataReader dr);

        string PrintableString(T entity);

    }
}