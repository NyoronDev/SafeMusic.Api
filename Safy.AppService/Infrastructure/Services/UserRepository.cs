using LiteDB;
using Microsoft.Extensions.Configuration;
using Safy.AppService.Infrastructure.Contracts;
using Safy.AppService.Models;

namespace Safy.AppService.Infrastructure.Services
{
    public class UserRepository : IUserRepository
    {
        private string dbLocation;

        public UserRepository(IConfiguration configuration)
        {
            dbLocation = configuration["DbLocation"];
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

        public bool SaveUser(User user)
        {
            using (var db = new LiteDatabase(dbLocation))
            {
                var userCollection = db.GetCollection<User>("users");
                userCollection.EnsureIndex(u => u.Id);
                var success = userCollection.Upsert(user);

                return success;
            }
        }
    }
}
