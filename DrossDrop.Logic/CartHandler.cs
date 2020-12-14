using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using MySqlX.XDevAPI.CRUD;
using Org.BouncyCastle.Crypto.Tls;
using System.Threading.Tasks;
using System.Linq;
using DrossDrop.DataInterface;
using DrossDrop.DTOs;
using DrossDrop.Factory;

namespace DrossDrop.Logic
{
    public class CartHandler
    {
        private readonly ICartData _cartdata = CartFactory.GetInstance();

        public Cart SelectAllItems(int userId)
        {
            Cart cart = (_cartdata).SelectAllItems(userId);

            return cart;
        }
        
        public void AddProductToCart(int userId, int productId)
        {
            _cartdata.AddProductToCart(userId, productId);
        }

        public void RemoveFromCart(int id)
        {
            _cartdata.RemoveFromCart(id);
        }
    }
}