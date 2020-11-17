using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sol_Demo.Services
{
    public class UserService : IUserService
    {
        string IUserService.DisplayUsers(UserModel userModel)
        {
            return $"{userModel.FirstName} {userModel.LastName}";
        }
    }
}