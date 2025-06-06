using UserAuthApp.Domain.Entities;
using UserAuthApp.Domain.Interfaces;

namespace UserAuthApp.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly INotificationService _notificationRepository;

        public InMemoryUserRepository(INotificationService notificationService)
        {
            _notificationRepository = notificationService;
        }

        private readonly List<User> users = new()
        {
            new User { Id = 1, Email = "test@example.com", Password = "password" },
            new User { Id = 2, Email = "test2@example.com", Password = "wrongpassword" }
        };

        public User? GetUserByEmail(string email)
        {
            return users.FirstOrDefault(u => u.Email == email);
        }

        public void UpdateUser(User user)
        {
            var existingUser = users.FirstOrDefault(u => u.Id == user.Id);

            if (existingUser != null)
            {
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
            }
        }
    }
}
