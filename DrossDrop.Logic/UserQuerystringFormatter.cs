using System;
using DrossDrop.Data;
using DrossDrop.DTOs;

namespace DrossDrop.Logic
{
    public class UserQuerystringFormatter
    {
        public string InsertFormatter(UserDTO user)
        {
            string querystring = "INSERT INTO users (userId, roleId, email, password, firstName, lastName) " +
                                 "VALUES ("+ user.userId +", "+ user.roleId +", "+ user.email +", "+ user.password +", "+ user.firstName +", "+ user.lastName +")";

            return querystring;
        }
    }
}
