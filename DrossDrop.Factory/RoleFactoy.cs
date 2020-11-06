using System;
using DrossDrop.Data;
using DrossDrop.Data.DALs;
using DrossDrop.Interface;

namespace DrossDrop.Factory
{
    public static class RoleFactory
    {
        public static IRoleData GetInstance()
        {
            return new RoleData();
        }
    }
}