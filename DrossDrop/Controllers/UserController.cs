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
        public async Task<IActionResult> Index()
        {
            return View(await handler.SelectAllAsync());
        }

        // Create: Opens a form where you can create a customer
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDTO user)
        {
            await handler.CreateAsync(user);

            return RedirectToAction("Index");
        }

        // Update: Opens a form with the specified user's information based on userId
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            UserDTO user = await handler.SelectByIdAsync(id);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserDTO user, int id)
        {
            await handler.UpdateAsync(user, id);

            return RedirectToAction("Index");
        }

        // Delete: Deletes specified user's information from database
        public async Task<IActionResult> Delete(int id)
        {
            await handler.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
