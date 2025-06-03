using UserAuthApp.Domain.Entities;

namespace UserAuthApp.Domain.Interfaces
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
    }
}
