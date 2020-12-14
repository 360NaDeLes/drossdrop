using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using MySqlX.XDevAPI.CRUD;
using Org.BouncyCastle.Crypto.Tls;
using System.Threading.Tasks;
using System.Linq;
using DrossDrop.DataInterface;
using DrossDrop.DTOs;
using DrossDrop.Factory;

namespace DrossDrop.Logic
{
    public class UserHandler
    {
        private readonly IUserData _userdata = UserFactory.GetInstance();
        private readonly EncryptionHelper helper = new EncryptionHelper();

        public void CreateUser(User user, string password)
        {
            user.salt = helper.CreateSalt(8);

            user.password = helper.HashString(password, user.salt);

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
            user.salt = helper.CreateSalt(8);

            user.password = helper.HashString(user.password, user.salt);

            _userdata.UpdateUser(user, id);
        }

        public void DeleteUser(int id)
        {
            _userdata.DeleteUser(id);
        }

        public User SelectUserByEmail(string email)
        {
            User user = _userdata.SelectUserByEmail(email);

            return user;
        }

        public User AttemptLogin(string email, string password)
        {
            User user = _userdata.SelectUserByEmail(email);

            if (user == null)
            {
                return null;
            }

            string inputpw = helper.HashString(password, user.salt);

            if (user.password != inputpw)
            {
                return null;
            }

            return user;
        }

        public bool AdminCheck(string email)
        {
            User user = _userdata.SelectUserByEmail(email);

            if (user.roleId == 2)
            {
                return true;
            }

            return false;
        }
    }
}
