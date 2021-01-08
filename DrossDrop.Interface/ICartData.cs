using DrossDrop.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrossDrop.DataInterface
{
    public interface ICartData
    {
        public Cart SelectAllItems(int userId);
        public void AddProductToCart(int userId, int productId);
        public void RemoveFromCart(int userId, int productId);
    }
}