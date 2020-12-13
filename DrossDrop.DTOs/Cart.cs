using System;
using System.Runtime.InteropServices;

namespace DrossDrop.DTOs
{
    public class Cart
    {
        public int cartId { get; set; }
        public int userId { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public decimal productPrice { get; set; }
    }
}