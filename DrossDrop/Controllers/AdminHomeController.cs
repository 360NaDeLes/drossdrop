using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DrossDrop.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DrossDrop.Models;
using DrossDrop.Data;
using DrossDrop.DTOs;
using DrossDrop.Logic;
using Microsoft.AspNetCore.Authorization;


namespace DrossDrop.Controllers
{
    [RequiredRoles("admin")]
    public class AdminHomeController : Controller
    {
        private ProductHandler handler = new ProductHandler();

        public IActionResult Index()
        {
            return View(handler.SelectAllProducts());
        }

        // Create: Opens a form where you can create a product
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Product product)
        {
            handler.CreateProduct(product);

            return RedirectToAction("Index");
        }

        // Update: Opens a form with the specified product's information based on productId
        [HttpGet]
        public IActionResult Update(int id)
        {
            Product product = handler.SelectProductById(id);

            return View(product);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Update(Product product, int id)
        {
            handler.UpdateProduct(product, id);

            return RedirectToAction("Index");
        }

        // Delete: Deletes specified product's information from database
        public IActionResult Delete(int id)
        {
            handler.DeleteProduct(id);

            return RedirectToAction("Index");
        }
    }
}
