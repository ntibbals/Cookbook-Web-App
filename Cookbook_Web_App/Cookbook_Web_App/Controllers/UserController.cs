using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Controllers
{
    public class UserController : Controller
    {
        private readonly CookbookDbContext _context;

        public UserController(CookbookDbContext context)
        {
            _context = context;
        }

        //Get User
        public IActionResult Index(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var user = await _context.User.FirstOrDefault(u => u.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        //Get: Create User
        public IActionResult Create()
        {
            return View();
        }

        //POST: create user
        [HttpPost]
        public async IActionResult Create([Bind ("ID,UserName")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }
    }
}
