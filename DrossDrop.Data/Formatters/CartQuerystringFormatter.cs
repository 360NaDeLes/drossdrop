using System;
using DrossDrop.Data;
using DrossDrop.DTOs;

namespace DrossDrop.Data.Formatters
{
    public class CartQuerystringFormatter
    {
        public string AddToCartFormatter(int userId, int productId)
        {
            string querystring = "INSERT INTO carts (userId, productId) " +
                                 "VALUES ("+ userId +", "+ productId +")";

            return querystring;
        }
        
        public string RemoveFromCartFormatter(int userId, int productId)
        {
            string querystring = "DELETE FROM carts WHERE userId = " + userId + " AND productId = " + productId + " LIMIT 1"; 

            return querystring;
        }
    }
}