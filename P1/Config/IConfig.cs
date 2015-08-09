using System.Data;
using P1.Enity;

namespace P1.Config
{
    public interface IConfig
    {
        string GetSelectAll();

        IEntity GetEntityFromReader(IDataReader dr);
    }
}