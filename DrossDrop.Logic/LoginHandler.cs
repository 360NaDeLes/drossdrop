using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrossDrop.Data;
using DrossDrop.DTOs;

namespace DrossDrop.Logic
{
    public class LoginHandler
    {
        private LoginQuerystringFormatter formatter = new LoginQuerystringFormatter();
        private DBConnection connection = new DBConnection();

        //public async Task ValidateUser(UserDTO user, string email, string password)
        //{
            //string querystring = formatter.ValidateUserFormatter(user, email, password);

           // await connection.ExecuteNonResponsiveQuery(querystring);
        //}

        public async Task<User> ValidateUser(User user, string email, string password)
        {
            string querystring = formatter.ValidateUserFormatter(user, email, password);

            user = await connection.ExecuteSelectUserQuery(querystring);

            return user;
        }
    }
}
