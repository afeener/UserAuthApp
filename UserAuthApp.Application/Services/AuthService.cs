using UserAuthApp.Domain.Interfaces;

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

            /* We could pull out the strings into constants inside a static Messages class.
                ex: 
                    public const string LoginSuccess = "User {0} logged in";)
                    ...
                    _notificationService.Notify(string.Format(Messages.LoginSuccessTemplate, email));

                This would let us keep all the messages in one place - easier to maintain and reuse. Could use the Messages class in unit testing too.
            */
            if (user != null && user.Password == password)
            {
                _notificationService.Notify($"User {email} logged in");
                return true;
            }

            //_notificationService.Notify(Messages.LoginFailed);
            return false;
        }
    }
}
