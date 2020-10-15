using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrossDrop.DTOs;
using DrossDrop.Logic;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;

namespace DrossDrop.Controllers
{
    public class LoginController : Controller
    {
        private UserHandler handler = new UserHandler();

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(User user, string email, string password)
        //{
        //    await handler.ValidateUser(user, email, password);

        //    return RedirectToAction("Index", "Home", new { area = "" });
        //}

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            handler.CreateUser(user);

            return RedirectToAction("Index");
        }
    }
}
