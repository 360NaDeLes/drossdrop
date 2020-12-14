using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrossDrop.Data.Formatters;
using DrossDrop.DTOs;
using DrossDrop.DataInterface;

namespace DrossDrop.Data
{
    public class RoleData : IRoleData
    {
        private RoleQuerystringFormatter formatter = new RoleQuerystringFormatter();
        private DBConnection db = new DBConnection();

        public Role SelectRoleByName(string name)
        {
            string querystring = formatter.SelectRoleByName(name);

            Role role = db.ExecuteSelectRoleQuery(querystring).FirstOrDefault();

            return role;
        }
    }
}
