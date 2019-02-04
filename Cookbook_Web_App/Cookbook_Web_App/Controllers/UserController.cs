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

        //Get: Edit user
        public async IActionResult Edit(int? id)
        {
            if (id == null)
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

        //Post: Edit user
        [HttpPost]
        public async IActionResult Edit(int id, [Bind("ID,UserName")] User user)
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
        }

        //Get Delete user
        public async IActionResult Delete(int id)
        {
            var user = await _context.User.FirstOrDefault(u => u.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        //Post Delete user
        [HttpPost, ActionName("Delete")]
        public async IActionResult ConfirmDelete(int id)
        {
            var user = await _context.User.FirstOrDefault(u => u.ID == id);
            _context.User.Remove(user);

            await _context.SaveChangesAsync();
            return RedirectToAction(Home) //TODO need to make home page;
        }


        private bool UserExists(int id)
        {
            return _context.User.Any(u => u.ID == id);
        }
    }
}
