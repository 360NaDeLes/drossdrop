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
    public class UserController : Controller
    {
        private UserHandler handler = new UserHandler();

        // Index: Gets all Users
        public IActionResult Index()
        {
            return View(handler.SelectAllUsers());
        }

        // Create: Opens a form where you can create a customer
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            handler.CreateUser(user);

            return RedirectToAction("Index");
        }

        // Update: Opens a form with the specified user's information based on userId
        [HttpGet]
        public IActionResult Update(int id)
        {
            User user = handler.SelectUserById(id);

            return View(user);
        }

        [HttpPost]
        public IActionResult Update(User user, int id)
        {
            handler.UpdateUser(user, id);

            return RedirectToAction("Index");
        }

        // Delete: Deletes specified user's information from database
        public IActionResult Delete(int id)
        {
            handler.DeleteUser(id);

            return RedirectToAction("Index");
        }
    }
}
