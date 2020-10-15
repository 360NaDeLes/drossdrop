using System;
using DrossDrop.Data;
using DrossDrop.DTOs;

namespace DrossDrop.Data.Formatters
{
    public class UserQuerystringFormatter
    {
        public string SelectByIdFormatter(int id)
        {
            string querystring = "SELECT * FROM users WHERE userId = " + id + ""; 

            return querystring;
        }

        public string InsertFormatter(User user)
        {
            string querystring = "INSERT INTO users (firstName, lastName, email, password) " +
                                 "VALUES ('"+ user.firstName +"', '"+ user.lastName +"', '"+ user.email +"', '"+ user.password +"')";

            return querystring;
        }

        public string UpdateFormatter(User user, int id)
        {
            string querystring = "UPDATE users SET roleId = " + user.roleId + ", email = '" + user.email +
                                 "', password = '" + user.password + "', firstName = '" + user.firstName +
                                 "', lastName = '" + user.lastName + "' WHERE userId = " + id + ""; 

            return querystring;
        }

        public string DeleteFormatter(int id)
        {
            string querystring = "DELETE FROM users WHERE userId = " + id + ""; 

            return querystring;
        }
    }
}
