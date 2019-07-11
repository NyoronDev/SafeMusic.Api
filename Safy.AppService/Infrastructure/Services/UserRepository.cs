using LiteDB;
using Safy.AppService.Infrastructure.Contracts;
using Safy.AppService.Models;

namespace Safy.AppService.Infrastructure.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly DbConfig dbConfig;

        public UserRepository(DbConfig dbConfig)
        {
            this.dbConfig = dbConfig;
        }

        public User GetUserById(int id)
        {
            using (var db = new LiteDatabase(dbConfig.DbLocation))
            {
                var userCollection = db.GetCollection<User>("users");
                var user = userCollection.FindById(id);

                return user;
            }
        }

        public User GetUser(string emailAddress)
        {
            using (var db = new LiteDatabase(dbConfig.DbLocation))
            {
                var userCollection = db.GetCollection<User>("users");
                var user = userCollection.FindOne(u => u.EmailAddress == emailAddress);

                return user;
            }
        }

        public bool SaveUser(User user)
        {
            using (var db = new LiteDatabase(dbConfig.DbLocation))
            {
                var userCollection = db.GetCollection<User>("users");
                userCollection.EnsureIndex(u => u.Id);
                var success = userCollection.Upsert(user);

                return success;
            }
        }
    }
}
