using UserAuthApp.Domain.Entities;
using UserAuthApp.Domain.Interfaces;

namespace UserAuthApp.Infrastructure.Repositories
{
    // Mock repo for testing - implement UserRepository when hooked into a DB.
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new()
        {
            new User { Id = 1, Email = "test@example.com", Password = "password" }
        };

        public User? GetUserByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }
    }
}
