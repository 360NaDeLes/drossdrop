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
    public class ProductHandler
    {
        private readonly IProductData _productdata = ProductFactory.GetInstance();

        public void CreateProduct(Product product)
        {
            _productdata.CreateProduct(product);
        }

        public IEnumerable<Product> SelectAllProducts()
        {
            List<Product> list = _productdata.SelectAllProducts().ToList();

            return list;
        }

        public Product SelectProductById(int id)
        {
            Product product = _productdata.SelectProductById(id);

            return product;
        }

        public void UpdateProduct(Product product, int id)
        {
            _productdata.UpdateProduct(product, id);
        }

        public void DeleteProduct(int id)
        {
            _productdata.DeleteProduct(id);
        }
    }
}