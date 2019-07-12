using System.Collections.Generic;
using Safy.AppService.Models;

namespace Safy.AppService.Infrastructure.Contracts
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        User GetUser(string emailAddress);
        List<User> GetUsers(int page, int size);
        bool UpdateUser(User user);
        //bool SaveUser(User user);
        int DeleteAllUsers();

        int RegisterUser(NewUser newUser);
        bool LoginUser(LoginUser loginUser);
    }
}
