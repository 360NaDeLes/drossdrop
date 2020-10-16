using DrossDrop.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrossDrop.Interface
{
    public interface IUserData
    {
        IEnumerable<User> SelectAllUsers();
        User SelectUserById(int id);
        void CreateUser(User user);
        void UpdateUser(User user, int id);
        void DeleteUser(int id);
        User SelectUserByEmail(string email);
    }
}
