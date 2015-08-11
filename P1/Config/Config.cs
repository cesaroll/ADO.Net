using System.Collections;
using System.Collections.Generic;
using System.Data;
using P1.Enity;
using P1.Interface.Config;
using P1.Interface.Entity;

namespace P1.Config
{
    public abstract class Config<T> : IConfig<T> where T : IEntity, new()
    {
        public abstract string SelectAllQuery { get; }
        
        public abstract T EntityFromReader(IDataReader dr);

        public abstract string PrintableString(T entity);

        public virtual string PrimaryKey { get { return "Id"; } }
    }
}