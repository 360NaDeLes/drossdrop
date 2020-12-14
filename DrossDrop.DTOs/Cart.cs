using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DrossDrop.DTOs
{
    public class Cart
    {
        public User user { get; set; }
        public List<Product> products { get; set; }
    }
}