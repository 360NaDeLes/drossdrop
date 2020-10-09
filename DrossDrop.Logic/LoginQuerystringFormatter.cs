using System;
using System.Collections.Generic;
using System.Text;
using DrossDrop.DTOs;
using DrossDrop.Data;

namespace DrossDrop.Logic
{
    public class LoginQuerystringFormatter
    {
        public string ValidateUserFormatter(UserDTO user, string email, string password)
        {
            string querystring = "SELECT * FROM users WHERE email = '" + email + "' AND password = '" + password + "'"; 

            return querystring;
        }
    }
}
