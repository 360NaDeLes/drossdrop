using DrossDrop.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrossDrop.Interface
{
    public interface IProductData
    {
        public IEnumerable<Product> SelectAllProducts();
        public Product SelectProductById(int id);
        public void CreateProduct(Product product);
        public void UpdateProduct(Product product, int id);
        public void DeleteProduct(int id);
    }
}