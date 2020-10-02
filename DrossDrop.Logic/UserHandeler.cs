using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DrossDrop.Data;
using DrossDrop.DTOs;
using MySqlX.XDevAPI.CRUD;
using Org.BouncyCastle.Crypto.Tls;
using System.Threading.Tasks;

namespace DrossDrop.Logic
{
    public class UserHandeler
    {
        private UserQuerystringFormatter formatter = new UserQuerystringFormatter();
        private DBConnection connection = new DBConnection();

        public async Task CreateAsync(UserDTO user)
        {
            string querystring = formatter.InsertFormatter(user);

            await connection.ExecuteInsert(querystring);
        }

        public async Task<IEnumerable<UserDTO>> SelectAllAsync()
        {
            return await connection.ExecuteSelect("SELECT * FROM users");
        }
    }
}
