using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DrossDrop.Models;
using DrossDrop.Data;
using DrossDrop.DTOs;
using DrossDrop.Logic;
using Microsoft.AspNetCore.Authorization;

namespace DrossDrop.Controllers
{
    public class CartController : Controller
    {
        private CartHandler cartHandler = new CartHandler();
        
        [HttpGet]
        public IActionResult Index(int userId)
        {
            return View(cartHandler.SelectAllItems(userId));
        }
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult AddToCart(int userId, int productId)
        {    
            cartHandler.AddProductToCart(userId, productId);

            return RedirectToAction("Index", "Cart", new { userId });
        }

        public IActionResult RemoveFromCart(int id)
        {
            cartHandler.RemoveFromCart(id);
            
            return View("Index");
        }
    }
}