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

        public async Task CreateAsync(UserDTO user)
        {
            string querystring = formatter.InsertFormatter(user);

            await connection.ExecuteNonResponsiveQuery(querystring);
        }

        public async Task<IEnumerable<UserDTO>> SelectAllAsync()
        {
            List<UserDTO> list = (await connection.ExecuteSelectQuery("SELECT * FROM users")).ToList();
            return list;
        }

        public async Task UpdateAsync(UserDTO user)
        {
            string querystring = formatter.UpdateFormatter(user);

            await connection.ExecuteNonResponsiveQuery(querystring);
        }

        public async Task<UserDTO> SelectByIdAsync(int userId)
        {
            UserDTO jez = new UserDTO();

            string querystring = formatter.SelectByIdFormatter(userId);

            jez = (await connection.ExecuteSelectQuery(querystring)).FirstOrDefault();

            return jez;
        }

        public async Task DeleteAsync(int userId)
        {
            string querystring = formatter.DeleteFormatter(userId);

            await connection.ExecuteNonResponsiveQuery(querystring);
        }
    }
}
