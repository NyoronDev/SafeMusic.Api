using System;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using Safy.AppService.Infrastructure.Contracts;
using Safy.AppService.Infrastructure.Services;
using Safy.AppService.Models;
using Xunit;

namespace Safy.UnitTests.UserTests
{
    public class UserRepositoryTests
    {
        private IUserRepository userRepository;

        public UserRepositoryTests()
        {
            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.SetupGet(s => s[It.IsAny<string>()]).Returns("C:/Repos/SafeMusic.Api/db/analplay.db");
            userRepository = new UserRepository(mockConfiguration.Object, new HashService());
        }

        //[Fact]
        //public void SaveUserShouldSucceed()
        //{
        //    var user = new User
        //    {
        //        Id = 1,
        //        CreateDateTime = DateTime.Now,
        //        EmailAddress = "test@safened.com",
        //        Name = "Test analyst"
        //    };
        //    var success = userRepository.SaveUser(user);

        //    success.Should().BeTrue();
        //}

        //[Fact]
        //public void RegisterUserShouldReturnUserId()
        //{
        //    var newUser = new NewUser
        //    {
        //        EmailAddress = "test@safened.com",
        //        Name = "Test analyst",
        //        Password = "12345"
        //    };

        //    var userId = userRepository.RegisterUser(newUser);

        //    userId.Should().BeGreaterThan(0);
        //}

        //[Fact]
        //public void GetUserShouldReturnUser()
        //{
        //    var givenEmailAddress = "test@safened.com";
        //    var user = userRepository.GetUser(givenEmailAddress);

        //    user.EmailAddress.Should().Be(givenEmailAddress);
        //    user.Id.Should().BeGreaterThan(0);
        //}

        [Fact]
        public void GetUsersShouldReturnUsers()
        {
            var page = 0;
            var size = 20;

            var users = userRepository.GetUsers(page, size);

            users.Count.Should().BeInRange(1, size);
        }

        //[Fact]
        //public void GetUserByIdShouldReturnUser()
        //{
        //    var id = 1;
        //    var user = userRepository.GetUserById(id);

        //    user.Id.Should().BeGreaterThan(0);
        //    user.EmailAddress.Should().NotBeEmpty();
        //}

        //[Fact]
        //public void DeleteAllUsersShouldRemoveAllUsersFromDb()
        //{
        //    var numberOfDeletedUsers = userRepository.DeleteAllUsers();

        //    numberOfDeletedUsers.Should().BeGreaterOrEqualTo(0);
        //}
    }
}
