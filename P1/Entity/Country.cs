namespace P1.Enity
{
    public class Country : IEntity
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0:###} {1,15}", ID, Name);
        }
    }
}