using System;

namespace Reservas.Domain.Entities
{
    public class Space
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public bool IsActive { get; private set; } = true;

        public Space(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            IsActive = true;
        }

        public void Deactivate() => IsActive = false;

        public void Activate() => IsActive = true;
    }
}
