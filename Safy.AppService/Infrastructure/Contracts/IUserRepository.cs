using Safy.AppService.Models;

namespace Safy.AppService.Infrastructure.Contracts
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        User GetUser(string emailAddress);
        bool SaveUser(User user);
    }
}
