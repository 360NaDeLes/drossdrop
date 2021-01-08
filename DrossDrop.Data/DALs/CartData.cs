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
                                                                    "FROM carts as c "+
                                                                    "INNER JOIN products as p ON c.productId = p.productId "+
                                                                    "WHERE c.userId = "+ userId +"");
            cart.user = new User()
            {
                userId = userId
            };
            
            return cart;
        }
        
        public void AddProductToCart(int userId, int productId)
        {
            string querystring = formatter.AddToCartFormatter(userId, productId);
            
            db.ExecuteNonResponsiveQuery(querystring);
        }

        public void RemoveFromCart(int userId, int productId)
        {
            string querystring = formatter.RemoveFromCartFormatter(userId, productId);

            db.ExecuteNonResponsiveQuery(querystring);
        }
    }
}