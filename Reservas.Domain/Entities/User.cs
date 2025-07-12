namespace Reservas.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public bool IsAdmin { get; private set; }

        public User(string name, string email, string passwordHash, bool isAdmin = false)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            IsAdmin = isAdmin;
        }
    }
}
