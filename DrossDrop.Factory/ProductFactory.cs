using System;
using DrossDrop.Data;
using DrossDrop.Data.DALs;
using DrossDrop.Interface;

namespace DrossDrop.Factory
{
    public static class Product
    {
        public static IProductData GetInstance()
        {
            return new ProductData();
        }
    }
}