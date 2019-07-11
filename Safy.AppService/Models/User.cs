using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
