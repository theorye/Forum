using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.AspServer.Models;
using Forum.AspServer.Services.Interfaces;
using Forum.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Forum.AspServer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            List<User> model = _userService.GetAll();

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserCreateModel user)
        {
            if (ModelState.IsValid)
            {
                _userService.Create(user);

                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
    }
}