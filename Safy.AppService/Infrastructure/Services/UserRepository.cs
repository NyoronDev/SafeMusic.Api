using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;
using Microsoft.Extensions.Configuration;
using Safy.AppService.Infrastructure.Contracts;
using Safy.AppService.Models;

namespace Safy.AppService.Infrastructure.Services
{
    public class UserRepository : IUserRepository
    {
        private string dbLocation;
        private readonly IHashService hashService;

        public UserRepository(IConfiguration configuration, IHashService hashService)
        {
            dbLocation = configuration["DbLocation"];
            this.hashService = hashService;
        }

        public User GetUserById(int id)
        {
            using (var db = new LiteDatabase(dbLocation))
            {
                var userCollection = db.GetCollection<User>("users");
                var user = userCollection.FindById(id);

                return user;
            }
        }

        public User GetUser(string emailAddress)
        {
            using (var db = new LiteDatabase(dbLocation))
            {
                var userCollection = db.GetCollection<User>("users");
                var user = userCollection.FindOne(u => u.EmailAddress == emailAddress);

                return user;
            }
        }

        public bool UpdateUser(User user)
        {
            if (user.Id == 0) throw new Exception("Not an existing user");

            using (var db = new LiteDatabase(dbLocation))
            {
                var userCollection = db.GetCollection<User>("users");
                var isUpdated = userCollection.Update(user);

                return isUpdated;
            }
        }

        //public bool SaveUser(User user)
        //{
        //    using (var db = new LiteDatabase(dbLocation))
        //    {
        //        var userCollection = db.GetCollection<User>("users");
        //        userCollection.EnsureIndex(u => u.Id);
        //        var isNewUser = userCollection.Upsert(user);

        //        return isNewUser;
        //    }
        //}

        public List<User> GetUsers(int page, int size)
        {
            using (var db = new LiteDatabase(dbLocation))
            {
                var userCollection = db.GetCollection<User>("users");                
                var users = userCollection.FindAll().Skip(page*size).Take(size);

                return users.ToList();
            }
        }

        public int DeleteAllUsers()
        {
            using (var db = new LiteDatabase(dbLocation))
            {
                var userCollection = db.GetCollection<User>("users");
                var numberOfDeletedUsers = userCollection.Delete(u => u != null);
                
                return numberOfDeletedUsers;
            }
        }

        public int RegisterUser(NewUser newUser)
        {
            if (string.IsNullOrEmpty(newUser.EmailAddress)) throw new ArgumentNullException(nameof(newUser.EmailAddress));
            if (string.IsNullOrEmpty(newUser.Password)) throw new ArgumentNullException(nameof(newUser.Password));

            var existingUser = GetUser(newUser.EmailAddress);
            if (existingUser != null) throw new Exception($"A user with email address {newUser.EmailAddress} already exists.");

            using (var db = new LiteDatabase(dbLocation))
            {
                var salt = hashService.CreateSalt();
                var user = new User
                {
                    EmailAddress = newUser.EmailAddress,
                    Name = newUser.Name,
                    CreateDateTime = DateTime.Now,
                    PasswordSalt = salt,
                    PasswordHash = hashService.CreateHash(newUser.Password, salt)
                };
            
                var userCollection = db.GetCollection<User>("users");
                userCollection.EnsureIndex(u => u.Id);
                var userId = userCollection.Insert(user);

                return userId.AsInt32;
            }
        }

        public bool LoginUser(LoginUser loginUser)
        {
            if (string.IsNullOrEmpty(loginUser.EmailAddress)) throw new ArgumentNullException(nameof(loginUser.EmailAddress));
            if (string.IsNullOrEmpty(loginUser.Password)) throw new ArgumentNullException(nameof(loginUser.Password));

            var user = GetUser(loginUser.EmailAddress);
            if (user == null) return false;

            var hashedPassword = hashService.CreateHash(loginUser.Password, user.PasswordSalt);
            var isValidLogin = user.PasswordHash == hashedPassword;

            if (!isValidLogin) return false;

            user.LastLoginDateTime = DateTime.Now;
            var isUpdated = UpdateUser(user);

            return isUpdated;
        }
    }
}
