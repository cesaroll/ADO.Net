using System.Data;
using P1.Enity;

namespace P1.Config
{
    public abstract class Config<T> : IConfig<T>
    {
        public abstract string GetSelectAllQuery();

        public abstract T GetEntityFromReader(IDataReader dr);
    }
}