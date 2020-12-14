using System;
using System.Collections.Generic;
using System.Text;
using DrossDrop.DTOs;
using DrossDrop.Factory;
using DrossDrop.DataInterface;

namespace DrossDrop.Logic
{
    public class RoleHandler
    {
        private readonly IRoleData _roledata = RoleFactory.GetInstance();

        public Role SelectRoleByName(string name)
        {
            Role role = _roledata.SelectRoleByName(name);

            return role;
        }
    }
}
