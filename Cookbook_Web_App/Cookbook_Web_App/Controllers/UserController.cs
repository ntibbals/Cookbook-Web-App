using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        //Get LOGIN
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userInput)
        {

            User user = _context.User.FirstOrDefault(u => u.UserName == userInput);
            if (user != null)
            {
                return RedirectToAction(nameof(Index), user);
            }
            else
            {
                return RedirectToAction(nameof(Create));
            }

        }
        //Get User
        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _context.User.FirstOrDefault(u => u.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        //Get: Create User
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST: create user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind ("ID,UserName")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), user);
            }

            return View(Index(user.ID));
        }

        //Get: Edit user
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user =  _context.User.FirstOrDefault(u => u.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        //Post: Edit user
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserName")] User user)
        {
            if (id != user.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();

                }
                catch (Exception)
                {
                    if (!UserExists(user.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
            }
            return RedirectToAction(nameof(Index), user);
        }

        //Get Delete user
        public async Task<IActionResult> Delete(int id)
        {
            var user = _context.User.FirstOrDefault(u => u.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        //Post Delete user
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var user = _context.User.FirstOrDefault(u => u.ID == id);
            _context.User.Remove(user);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
                //TODO Redirect to home page instead of dead index page
        }


        private bool UserExists(int id)
        {
            return _context.User.Any(u => u.ID == id);
        }
    }
}
