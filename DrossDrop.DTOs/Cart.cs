using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DrossDrop.DTOs
{
    public class Cart
    {
        public int cartId { get; set; }
        public User user { get; set; }
        public List<Product> products { get; set; }
    }
}