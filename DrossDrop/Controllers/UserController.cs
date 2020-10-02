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
        private UserHandeler newUser = new UserHandeler();

        [HttpPost]
        public async Task<IActionResult> Create(UserDTO user)
        {
            await newUser.CreateAsync(user);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            return View(await newUser.SelectAllAsync());
        }
    }
}
