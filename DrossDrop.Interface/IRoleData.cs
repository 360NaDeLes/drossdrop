using DrossDrop.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrossDrop.Interface
{
    public interface IRoleData{
        Role SelectRoleByName(string name);
    }
}