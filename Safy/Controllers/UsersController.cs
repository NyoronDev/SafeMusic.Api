using Microsoft.AspNetCore.Mvc;
using Safy.AppService.Infrastructure.Contracts;
using Safy.AppService.Models;

namespace Safy.Api.Controllers
{
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [Route("/v1/users/{id}")]
        [HttpGet]
        public User GetUserById(int id)
        {
            var user = userRepository.GetUserById(id);

            return user;
        }

        [Route("/v1/users")]
        [HttpPost]
        public int RegisterUser(NewUser newUser)
        {
            var userId = userRepository.RegisterUser(newUser);

            return userId;
        }

        [Route("/v1/loginuser")]
        [HttpPost]
        public bool Login(LoginUser loginUser)
        {
            var isLoggedIn = userRepository.LoginUser(loginUser);

            return isLoggedIn;
        }


    }
}