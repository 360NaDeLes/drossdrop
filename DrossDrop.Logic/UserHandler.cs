using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using MySqlX.XDevAPI.CRUD;
using Org.BouncyCastle.Crypto.Tls;
using System.Threading.Tasks;
using System.Linq;
using DrossDrop.Interface;
using DrossDrop.DTOs;
using DrossDrop.Factory;

namespace DrossDrop.Logic
{
    public class UserHandler
    {
        private readonly IUserData _userdata = UserFactory.GetInstance();

        public void CreateUser(User user)
        {
            _userdata.CreateUser(user);
        }

        public IEnumerable<User> SelectAllUsers()
        {
            List<User> list = _userdata.SelectAllUsers().ToList();

            return list;
        }

        public User SelectUserById(int id)
        {
            User user = _userdata.SelectUserById(id);

            return user;
        }

        public void UpdateUser(User user, int id)
        {
            _userdata.UpdateUser(user, id);
        }

        public void DeleteUser(int id)
        {
            _userdata.DeleteUser(id);
        }
    }
}
