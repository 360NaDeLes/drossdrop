using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using DrossDrop.DTOs;
using DrossDrop.Logic;
using DrossDrop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Renci.SshNet;

namespace DrossDrop.Controllers
{
    public class LoginController : Controller
    {
        // Session vars
        public const string SessionEmail = "_Email";
        public const string SessionName = "_Name";
        public const string SessionId = "_Id";
        public const string LoggedIn = "_LoggedIn";

        // Create new instance of Logic layer classes
        private UserHandler handler = new UserHandler();

        public IActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var user = handler.AttemptLogin(model.email, model.password);

            if (user != null)
            {
                HttpContext.Session.SetString(SessionEmail, user.email);
                HttpContext.Session.SetString(SessionName, user.firstName);
                HttpContext.Session.SetInt32(SessionId, user.userId);
                HttpContext.Session.SetString(LoggedIn, "true");
                
                var isAdmin = handler.AdminCheck(model.email);

                if (isAdmin)
                {
                    return RedirectToAction("Index", "AdminHome");
                }

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("email", "De ingevoerde gegevens kloppen niet.");

            return View("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (String.IsNullOrWhiteSpace(model.firstName) || String.IsNullOrWhiteSpace(model.lastName) || String.IsNullOrWhiteSpace(model.email) || String.IsNullOrWhiteSpace(model.password))
                {
                    ModelState.AddModelError("firstName", "Zorg dat alle velden zijn ingevuld.");
                
                    return View(model);
                }
            }
            
            User user = new User()
            {
                firstName = model.firstName,
                lastName = model.lastName,
                email = model.email
            };

            handler.CreateUser(user, model.password);

            return RedirectToAction("Index", "Login");
        }
    }
}
