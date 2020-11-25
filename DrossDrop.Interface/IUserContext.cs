using System;
using System.Collections.Generic;
using System.Text;
using DrossDrop.DTOs;

namespace DrossDrop.DataInterface
{
    public interface IUserContext
    {
        IEnumerable<User> SelectAllUsers();
        User SelectUserById(int id);
        void CreateUser(User user);
        void UpdateUser(User user, int id);
        void DeleteUser(int id);
        User SelectUserByEmail(string email);
    }
}
