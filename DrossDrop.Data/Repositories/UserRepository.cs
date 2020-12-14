using System;
using System.Collections.Generic;
using System.Text;
using DrossDrop.DataInterface;
using DrossDrop.DTOs;
using DrossDrop.DataInterface;

namespace DrossDrop.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IUserContext context;

        public UserRepository(IUserContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> SelectAllUsers()
        {
            return context.SelectAllUsers();
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
