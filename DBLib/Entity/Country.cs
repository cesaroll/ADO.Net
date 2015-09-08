using Base.Interface.Entity;

namespace DB.Entity
{
    public class Country : IEntity
    {
        public int ID { get; set; }

        public string Name { get; set; }

    }
}