using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DrossDrop.Data;
using DrossDrop.DTOs;
using MySqlX.XDevAPI.CRUD;
using Org.BouncyCastle.Crypto.Tls;
using System.Threading.Tasks;

namespace DrossDrop.Logic
{
    public class UserHandler
    {
        private UserQuerystringFormatter formatter = new UserQuerystringFormatter();
        private DBConnection connection = new DBConnection();

        public async Task CreateAsync(User user)
        {
            string querystring = formatter.InsertFormatter(user);

            await connection.ExecuteNonResponsiveQuery(querystring);
        }

        public async Task<IEnumerable<User>> SelectAllAsync()
        {
            List<User> list = (await connection.ExecuteSelectUserQuery("SELECT * FROM users")).ToList();

            return list;
        }

        public async Task<User> SelectByIdAsync(int id)
        {
            User user = new User();

            string querystring = formatter.SelectByIdFormatter(id);

            UserDTO udt = (await connection.ExecuteSelectUserQuery(querystring)).FirstOrDefault();

            user.userId = udt.userId;
            user.roleId = udt.roleId;
            user.email = udt.email;
            user.password = udt.password;
            user.firstName = udt.firstName;
            user.lastName = udt.lastName;

            return user;
        }

        public async Task UpdateAsync(User user, int id)
        {
            string querystring = formatter.UpdateFormatter(user, id);

            await connection.ExecuteNonResponsiveQuery(querystring);
        }

        public async Task DeleteAsync(int id)
        {
            string querystring = formatter.DeleteFormatter(id);

            await connection.ExecuteNonResponsiveQuery(querystring);
        }
    }
}
