﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrossDrop.Data.Formatters;
using DrossDrop.DTOs;
using DrossDrop.DataInterface;

namespace DrossDrop.Data.DALs
{
    public class ProductData : IProductData
    {
        private ProductQuerystringFormatter formatter = new ProductQuerystringFormatter();
        private DBConnection db = new DBConnection();

        public void CreateProduct(Product product, decimal productPrice)
        {
            string querystring = formatter.InsertFormatter(product, productPrice);

            db.ExecuteNonResponsiveQuery(querystring);
        }

        public IEnumerable<Product> SelectAllProducts()
        {
            List<Product> list = db.ExecuteSelectProductQuery("SELECT Products.* FROM Products").ToList();

            return list;
        }

        public Product SelectProductById(int id)
        {
            string querystring = formatter.SelectByIdFormatter(id);

            Product product = db.ExecuteSelectProductQuery(querystring).FirstOrDefault();

            return product;
        }

        public void UpdateProduct(Product product, int id)
        {
            string querystring = formatter.UpdateFormatter(product, id);

            db.ExecuteNonResponsiveQuery(querystring);
        }

        public void DeleteProduct(int id)
        {
            string querystring = formatter.DeleteFormatter(id);

            db.ExecuteNonResponsiveQuery(querystring);
        }

        
    }
}