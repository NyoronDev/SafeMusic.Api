using Microsoft.AspNetCore.Mvc;
using Safy.AppService.Infrastructure.Contracts;
using Safy.AppService.Models;

namespace Safy.Api.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User GetUserById(int id)
        {
            var user = userRepository.GetUserById(id);

            return user;
        }
    }
}