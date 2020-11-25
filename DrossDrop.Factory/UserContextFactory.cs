using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using DrossDrop.CustomConfig;
using DrossDrop.Data.Contexts;
using DrossDrop.Data.DALs;
using DrossDrop.Data.Repositories;
using DrossDrop.DataInterface;
using DrossDrop.Interface;

namespace DrossDrop.Factory
{
    public static class UserContextFactory
    {
        public static IUserContext GetInstance()
        {

            if(CustomConfigFile.DataEnvironment == "SQL") 
                return new UserContext();

            //else if(CustomConfigFile.DataEnvironment == "MemoryContext")
            //    return new MemoryContext();

            return null;
        }
    }
}
