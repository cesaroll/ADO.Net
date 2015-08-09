using System.Data;
using P1.Enity;

namespace P1.Config
{
    public class Config : IConfig
    {
        public virtual string GetSelectAll()
        {
            throw new System.NotImplementedException();
        }

        public virtual IEntity GetEntityFromReader(IDataReader dr)
        {
            throw new System.NotImplementedException();
        }
    }
}