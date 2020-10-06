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

        public async Task<UserDTO> SelectByIdAsync(int id)
        {
            UserDTO user = new UserDTO();

            string querystring = formatter.SelectByIdFormatter(id);

            user = (await connection.ExecuteSelectQuery(querystring)).FirstOrDefault();

            return user;
        }

        public async Task UpdateAsync(UserDTO user, int id)
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
