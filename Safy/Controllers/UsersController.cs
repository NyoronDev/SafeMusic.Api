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
    }
}