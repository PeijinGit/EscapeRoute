using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class User
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string Token { get; set; }

        public User(string userId = "QWE", string passWord="123", string type="normal", string token="Null")
        {
            UserId = userId;
            Password = passWord;
            Type = type;
            Token = token;
        }
    }
}
