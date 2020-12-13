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
        private ProductHandler productHandler = new ProductHandler();

        public IActionResult Index()
        {
            return View(productHandler.SelectAllProducts());
        }
        
        
    }
}
