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

        public async Task<IActionResult> Index()
        {
            return View(await handler.SelectAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDTO user)
        {
            await handler.CreateAsync(user);

            return RedirectToAction("Index");
        }

        private string fff()
        {
            return "fff";
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserDTO user)
        {
            await handler.UpdateAsync<UserDTO>(user);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int userId)
        {
            UserDTO user = await handler.SelectByIdAsync(userId);

            return View(user);
        }


    }
}
