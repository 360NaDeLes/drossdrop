using System;
using DrossDrop.Data;
using DrossDrop.Data.DALs;
using DrossDrop.DataInterface;

namespace DrossDrop.Factory
{
    public static class UserFactory
    {
        public static IUserData GetInstance()
        {
            return new UserData();
        }
    }
}
