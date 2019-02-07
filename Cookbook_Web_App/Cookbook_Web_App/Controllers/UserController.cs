using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Cookbook_Web_App.Models.Interfaces;

namespace Cookbook_Web_App.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _context;

        public UserController(IUser context)
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
        public async Task<IActionResult> Login(string userInput)
        {

            var users = await _context.GetUsersAsync();
            var user = users.FirstOrDefault(u => u.UserName == userInput);
            if (user != null)
            {
                
                HttpContext.Session.SetString("UserName", user.UserName);
                return RedirectToAction(nameof(Index), user);
            }
            else
            {
                return RedirectToAction(nameof(Create));
            }

        }
        //Get User
        public async  Task<IActionResult> Index()
        {
            var name = HttpContext.Session.GetString("UserName");
            var users = await _context.GetUsersAsync();
            User user = users.FirstOrDefault(u => u.UserName == name);

            if (user == null)
            {
                return RedirectToAction(nameof(Create));
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
        public async Task<IActionResult> Create([Bind("ID,UserName")] User user)
        {
            if (ModelState.IsValid)
            {
                var users = await _context.GetUsersAsync();
                foreach (var u in users)
                {
                    if (u.UserName == user.UserName)
                    {                        
                        return RedirectToAction(nameof(Create2));
                    }
                }
                await _context.CreateUser(user);
                HttpContext.Session.SetString("UserName", user.UserName);
                return RedirectToAction(nameof(Index), user);
            }

            return RedirectToAction("Index");
        }

        //Get: Edit user
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var users = await _context.GetUsersAsync();
            var user = users.FirstOrDefault(u => u.ID == id);
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
                    await _context.UpdateUser(user);

                }
                catch (Exception)
                {
                    bool tester = await UserExistsAsync(user.ID);
                    if (!tester)
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
            var users = await _context.GetUsersAsync();
            var user = users.FirstOrDefault(u => u.ID == id);
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

            await _context.DeleteUser(id);
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index", "Home");
        }


        private async Task<bool> UserExistsAsync(int id)
        {
            var users = await _context.GetUsersAsync();
            return users.Any(u => u.ID == id);
        }


        //--------------------------------------------//
        //Get: Create User
        [HttpGet]
        public IActionResult Create2()
        {
            return View();
        }

        //POST: create user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create2([Bind("ID,UserName")] User user)
        {
            if (ModelState.IsValid)
            {
                var users = await _context.GetUsersAsync();
                foreach (var u in users)
                {
                    if (u.UserName == user.UserName)
                    {
                        return RedirectToAction(nameof(Create2));
                    }
                }
                await _context.CreateUser(user);
                HttpContext.Session.SetString("UserName", user.UserName);
                return RedirectToAction(nameof(Index), user);
            }

            return RedirectToAction("Index");
        }
    }
}