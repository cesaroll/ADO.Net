using System.Data;
using P1.Enity;

namespace P1.Config
{
    public abstract class Config<T> : IConfig<T> where T : IEntity, new()
    {
        public abstract string GetSelectAllQuery();

        public abstract T GetEntityFromReader(IDataReader dr);

        public abstract string PrintableString(T entity);
    }
}