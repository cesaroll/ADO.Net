using System.Data;
using Base.Interface.Config;
using Base.Interface.Entity;

namespace Base.Config
{
    public abstract class Config<T> : IConfig<T> where T : IEntity, new()
    {
        public abstract string SelectAllQuery { get; }
        
        public abstract T EntityFromReader(IDataReader dr);

        public abstract string PrintableString(T entity);

        public virtual string PrimaryKey { get { return "Id"; } }
    }
}