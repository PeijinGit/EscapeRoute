using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IUser
    {
        public User Login(string userName, string passWord);
    }
}
