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

        public Cart SelectAllItems(int userId)
        {
            Cart cart = db.ExecuteSelectCartQuery("SELECT p.*, c.cartId "+
                                                                    "FROM users as u "+
                                                                    "INNER JOIN carts as c ON u.cartId = c.cartId "+
                                                                    "INNER JOIN products as p ON c.productId = p.productId "+
                                                                    "WHERE u.userId = "+ userId +"");

            return cart;
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