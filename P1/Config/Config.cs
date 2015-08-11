using System.Data;
using P1.Enity;

namespace P1.Config
{
    public abstract class Config<T> : IConfig<T> where T : IEntity, new()
    {
        public abstract string SelectAllQuery { get; }
        public virtual string PrimaryKey { get { return "Id"; } }

        public abstract T EntityFromReader(IDataReader dr);

        public abstract string PrintableString(T entity);
    }
}