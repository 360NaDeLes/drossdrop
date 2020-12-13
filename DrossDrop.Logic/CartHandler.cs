using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using MySqlX.XDevAPI.CRUD;
using Org.BouncyCastle.Crypto.Tls;
using System.Threading.Tasks;
using System.Linq;
using DrossDrop.Interface;
using DrossDrop.DTOs;
using DrossDrop.Factory;

namespace DrossDrop.Logic
{
    public class CartHandler
    {
        private readonly ICartData _cartdata = CartFactory.GetInstance();

        public IEnumerable<Cart> SelectAllItems(int userId)
        {
            List<Cart> list = (_cartdata).SelectAllItems(userId).ToList();

            return list;
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