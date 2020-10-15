using DrossDrop.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrossDrop.Interface
{
    public interface IUserData
    {
        public IEnumerable<User> SelectAllUsers();
        public User SelectUserById(int id);
        public void CreateUser(User user);
        public void UpdateUser(User user, int id);
        public void DeleteUser(int id);
    }
}
