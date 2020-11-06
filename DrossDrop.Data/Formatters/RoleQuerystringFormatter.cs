using System;
using DrossDrop.Data;
using DrossDrop.DTOs;

namespace DrossDrop.Data.Formatters
{
    public class RoleQuerystringFormatter
    {
        public string SelectRoleByName(string name)
        {
            string querystring = "SELECT * FROM roles WHERE roleName = '" + name + "'"; 

            return querystring;
        }

    }
}