using System;
using System.Collections.Generic;
using System.Text;

namespace DrossDrop.DTOs
{
    public class User
    {
        public int userId { get; set; }
        public int roleId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string salt { get; set; }
    }
}
