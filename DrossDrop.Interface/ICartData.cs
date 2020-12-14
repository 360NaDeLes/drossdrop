using DrossDrop.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrossDrop.DataInterface
{
    public interface ICartData
    {
        public IEnumerable<Cart> SelectAllItems(int userId);
        public void AddProductToCart(int userId, int productId);
        public void RemoveFromCart(int userId);
    }
}