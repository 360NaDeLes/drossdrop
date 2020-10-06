using System;
using DrossDrop.Data;
using DrossDrop.DTOs;

namespace DrossDrop.Logic
{
    public class UserQuerystringFormatter
    {
        public string InsertFormatter(UserDTO user)
        {
            string querystring = "INSERT INTO users (roleId, email, password, firstName, lastName) " +
                                 "VALUES ("+ user.roleId +", '"+ user.email +"', '"+ user.password +"', '"+ user.firstName +"', '"+ user.lastName +"')";

            return querystring;
        }

        public string UpdateFormatter(UserDTO user)
        {
            string querystring = "UPDATE users SET roleId = " + user.roleId + ", email = '" + user.email +
                                 "', password = '" + user.password + "', firstName = '" + user.firstName +
                                 "', lastName = '" + user.lastName + "' WHERE userId = " + user.userId + ""; 

            return querystring;
        }

        public string DeleteFormatter(int userId)
        {
            string querystring = "DELETE FROM users WHERE userId = " + userId + ""; 

            return querystring;
        }

        public string SelectByIdFormatter(int userId)
        {
            string querystring = "SELECT FROM users WHERE userId = " + userId + ""; 

            return querystring;
        }
    }
}
