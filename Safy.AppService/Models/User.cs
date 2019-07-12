using System;

namespace Safy.AppService.Models
{
    public class User
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }        
        public DateTime LastLoginDateTime { get; set; }
        public DateTime LastActionDateTime { get; set; }
        public DateTime CreateDateTime { get; set; }   
        public byte[] PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
    }
}
