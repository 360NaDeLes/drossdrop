using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrossDrop.Data.Formatters;
using DrossDrop.DTOs;
using DrossDrop.DataInterface;

namespace DrossDrop.Data.DALs
{
    public class CartData : ICartData
    {
        private CartQuerystringFormatter formatter = new CartQuerystringFormatter();
        private DBConnection db = new DBConnection();

        public IEnumerable<Cart> SelectAllItems(int userId)
        {
            List<Cart> list = db.ExecuteSelectCartQuery("SELECT Carts.* FROM Carts WHERE userId = " + userId + "").ToList();

            return list;
        }
        
        public void AddProductToCart(int userId, int productId)
        {
            string querystring = formatter.AddToCartFormatter(userId, productId);
            
            db.ExecuteNonResponsiveQuery(querystring);
        }

        public void RemoveFromCart(int id)
        {
            string querystring = formatter.RemoveFromCartFormatter(id);

            db.ExecuteNonResponsiveQuery(querystring);
        }
    }
}