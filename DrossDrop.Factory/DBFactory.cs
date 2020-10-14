using System;
using DrossDrop.Data;
using DrossDrop.Interface;

namespace DrossDrop.Factory
{
    public static class DBFactory
    {
        public static IData GetInstance()
        {
            return new DBConnection();
        }
    }
}
