using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sol_Demo.Services
{
    public interface IUserService
    {
        String DisplayUsers(UserModel userModel);
    }
}