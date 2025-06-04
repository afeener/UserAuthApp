using UserAuthApp.Domain.Interfaces;
using UserAuthApp.Common;

namespace UserAuthApp.Application.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly INotificationService _notificationService;

        public AuthService(IUserRepository userRepository, INotificationService notificationService)
        {
            _userRepository = userRepository;
            _notificationService = notificationService;
        }

        public bool Authenticate(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);

            if (user == null || user.Password != password)
            {

                _notificationService.Notify(Messages.InvalidCredentials);
                return false;
            }

            _notificationService.Notify(Messages.UserLoggedIn(email));
             return true;
        }
    }
}
