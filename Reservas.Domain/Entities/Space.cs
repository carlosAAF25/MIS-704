namespace Reservas.Domain.Entities
{
    public class Space
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Space(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
