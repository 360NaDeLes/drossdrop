using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using DrossDrop.Data.DALs;
using DrossDrop.Data.Repositories;
using DrossDrop.DataInterface;

namespace DrossDrop.Factory
{
    public static class UserRepositoryFactory
    {
        public static IUserRepository GetInstance(IUserContext DataEnvironment)
        {
            return new UserRepository(DataEnvironment);
        }
    }
}
