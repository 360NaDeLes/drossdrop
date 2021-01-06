using System;
using System.ComponentModel.DataAnnotations;

namespace DrossDrop.DTOs
{
    public class Product
    {
        public int productId { get; set; }
        [Required(ErrorMessage = "Dit veld is vereist")]
        public string productName { get; set; }
        [Required(ErrorMessage = "Dit veld is vereist")]
        public decimal productPrice { get; set; }
        [Required(ErrorMessage = "Dit veld is vereist")]
        public string productImage { get; set; }

    }
}
