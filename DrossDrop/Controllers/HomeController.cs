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
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ProductHandler productHandler = new ProductHandler();
        private UserHandler userHandler = new UserHandler();

        public IActionResult Index()
        {
            return View(productHandler.SelectAllProducts());
        }
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult AddToCart(int userId, int productId)
        {
            userHandler.SelectUserById(userId);
            productHandler.SelectProductById(productId);
            productHandler.AddProductToCart(user.userId, product.productId);

            return RedirectToAction("Index");
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
