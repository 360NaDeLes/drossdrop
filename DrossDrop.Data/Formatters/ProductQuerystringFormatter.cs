using System;
using DrossDrop.Data;
using DrossDrop.DTOs;

namespace DrossDrop.Data.Formatters
{
    public class ProductQuerystringFormatter
    {
        public string SelectByIdFormatter(int id)
        {
            string querystring = "SELECT * FROM products WHERE productId = " + id + ""; 

            return querystring;
        }

        public string InsertFormatter(Product product)
        {
            string querystring = "INSERT INTO products (productName, productPrice) " +
                                 "VALUES ('"+ product.productName +"', "+ product.productPrice +")";

            return querystring;
        }

        public string UpdateFormatter(Product product, int id)
        {
            string querystring = "UPDATE products SET productName = '" + product.productName + "', productPrice = " +
                                 product.productPrice + "";

            return querystring;
        }

        public string DeleteFormatter(int id)
        {
            string querystring = "DELETE FROM products WHERE productId = " + id + ""; 

            return querystring;
        }
    }
}