using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrossDrop.Data.Formatters;
using DrossDrop.DataInterface;
using DrossDrop.DTOs;

namespace DrossDrop.Data.Contexts
{
    public class UserContext : IUserContext
    {
        private UserQuerystringFormatter formatter = new UserQuerystringFormatter();
        private DBConnection db = new DBConnection();

        public IEnumerable<User> SelectAllUsers()
        {
            List<User> list = db.ExecuteSelectUserQuery("SELECT * FROM users").ToList();

            return list;
        }

        public User SelectUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user, int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public User SelectUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
